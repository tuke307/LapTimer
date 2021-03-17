using MvvmCross.Base;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LapTimer.Test
{
    /// <summary>
    /// MvxMockViewDispatcher.
    /// </summary>
    /// <seealso cref="MvvmCross.Base.MvxMainThreadDispatcher" />
    /// <seealso cref="MvvmCross.Views.IMvxViewDispatcher" />
    public class MvxMockViewDispatcher : MvxMainThreadDispatcher, IMvxViewDispatcher
    {
        /// <summary>
        /// The hints.
        /// </summary>
        public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

        /// <summary>
        /// The requests.
        /// </summary>
        public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();

        /// <summary>
        /// Gets a value indicating whether this instance is on main thread.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is on main thread; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="NotImplementedException"></exception>
        public override bool IsOnMainThread => throw new NotImplementedException();

        /// <summary>
        /// Changes the presentation.
        /// </summary>
        /// <param name="hint">The hint.</param>
        /// <returns></returns>
        public Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            Hints.Add(hint);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Executes the on main thread asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="maskExceptions">if set to <c>true</c> [mask exceptions].</param>
        /// <returns></returns>
        public Task ExecuteOnMainThreadAsync(Action action, bool maskExceptions = true)
        {
            action();
            return Task.FromResult(true);
        }

        /// <summary>
        /// Executes the on main thread asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="maskExceptions">if set to <c>true</c> [mask exceptions].</param>
        /// <returns></returns>
        public Task ExecuteOnMainThreadAsync(Func<Task> action, bool maskExceptions = true)
        {
            action();
            return Task.FromResult(true);
        }

        /// <summary>
        /// Requests the main thread action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="maskExceptions">if set to <c>true</c> [mask exceptions].</param>
        /// <returns></returns>
        public override bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            action();
            return true;
        }

        /// <summary>
        /// Shows the view model.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Task<bool> ShowViewModel(MvxViewModelRequest request)
        {
            Requests.Add(request);
            return Task.FromResult(true);
        }
    }
}