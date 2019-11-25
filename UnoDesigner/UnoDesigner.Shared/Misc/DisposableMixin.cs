﻿using System;
using System.Reactive.Disposables;

namespace UnoDesigner.Misc
{
    public static class DisposableMixin
    {
        /// <summary>
        /// Ensures the provided disposable is disposed with the specified <see cref="CompositeDisposable"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the disposable.
        /// </typeparam>
        /// <param name="item">
        /// The disposable we are going to want to be disposed by the CompositeDisposable.
        /// </param>
        /// <param name="compositeDisposable">
        /// The <see cref="CompositeDisposable"/> to which <paramref name="item"/> will be added.
        /// </param>
        /// <returns>
        /// The disposable.
        /// </returns>
        public static T DisposeWith<T>(this T item, CompositeDisposable compositeDisposable)
        where T : IDisposable
        {
            if (compositeDisposable == null)
            {
                throw new ArgumentNullException(nameof(compositeDisposable));
            }

            compositeDisposable.Add(item);
            return item;
        }
    }
}