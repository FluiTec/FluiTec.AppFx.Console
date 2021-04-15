using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace FluiTec.AppFx.Console.Items
{
    /// <summary>   A base interactive console item. </summary>
    public abstract class BaseInteractiveConsoleItem : IInteractiveConsoleItem
    {
        private InteractiveConsoleHost _host;

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; protected set; }

        /// <summary>   Gets or sets the description. </summary>
        /// <value> The description. </value>
        public string Description { get; protected set; }

        /// <summary>   Gets or sets the host. </summary>
        /// <value> The host. </value>
        public InteractiveConsoleHost Host
        {
            get => _host ?? Parent?.Host;
            set => _host = value;
        }

        /// <summary>   Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        public IInteractiveConsoleItem Parent { get; set; }

        /// <summary>   Gets a value indicating whether this  has parent. </summary>
        /// <value> True if this  has parent, false if not. </value>
        public virtual bool HasParent => Parent != null;

        /// <summary>   Gets the children. </summary>
        /// <value> The children. </value>
        public IList<IInteractiveConsoleItem> Children { get; }

        /// <summary>   Gets a value indicating whether this  has children. </summary>
        /// <value> True if this  has children, false if not. </value>
        public bool HasChildren => Children != null && Children.Any();

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        private BaseInteractiveConsoleItem()
        {
            Children = new ObservableCollection<IInteractiveConsoleItem>();

            // auto-set parent
            var observableChildren = Children as ObservableCollection<IInteractiveConsoleItem>;
            Debug.Assert(observableChildren != null);
            observableChildren.CollectionChanged += ObservableChildrenOnCollectionChanged;
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="name">         The name. </param>
        /// <param name="description">  The description. </param>
        /// <param name="parent">       The parent. </param>
        protected BaseInteractiveConsoleItem(string name, string description, IInteractiveConsoleItem parent = null) : this()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));

            Name = name;
            Description = description;
            Parent = parent;
        }

        /// <summary>   Executes the picked action. </summary>
        /// <remarks>   
        ///             Will be triggered upon getting the item selected. 
        ///             Will trigger auto-pick, when item has children
        /// </remarks>
        public virtual void OnPicked()
        {
            if (HasChildren)
                Host.Presenter.Pick(Children);
        }

        /// <summary>   Observable children on collection changed. </summary>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Notify collection changed event information. </param>
        protected virtual void ObservableChildrenOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                SetParent(e.NewItems.Cast<IInteractiveConsoleItem>(), this);
            if (e.OldItems != null)
                SetParent(e.OldItems.Cast<IInteractiveConsoleItem>(), null);
        }

        /// <summary>   Sets a parent. </summary>
        /// <param name="children"> The children. </param>
        /// <param name="parent">   (Optional) The parent. </param>
        protected virtual void SetParent(IEnumerable<IInteractiveConsoleItem> children,
            IInteractiveConsoleItem parent)
        {
            foreach (var child in children)
                child.Parent = parent;
        }
    }
}