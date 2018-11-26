using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FitnessDesktop.Models
{
    [Serializable]
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor for <see cref="NotificationObject"/>.
        /// </summary>
        public NotificationObject()
        {

        }
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary> 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged is null)
                return;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises this object's PropertyChanged event for each of the properties.
        /// </summary>
        /// <param name="propertyNames">The properties that have a new value.</param>
        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged is null)
                return;

            if (propertyNames is null)
                throw new ArgumentNullException(nameof(propertyNames));

            string[] strArrays = propertyNames;
            foreach (string propertyName in strArrays)
            {
                this.RaisePropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that has a new value</typeparam>
        /// <param name="propertyExpression">A Lambda expression representing the property that has a new value.</param>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            var propertyName = PropertySupport.ExtractPropertyName<T>(propertyExpression);
            if (!Dispatcher.CurrentDispatcher.CheckAccess())
            {
                Dispatcher.CurrentDispatcher.Invoke(new Action(() => RaisePropertyChanged(propertyName)));
            }
            else
            {
                RaisePropertyChanged(propertyName);
            }
        }
    }
}
