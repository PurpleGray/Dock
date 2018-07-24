﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dock.Model
{
    /// <summary>
    /// Dock base class.
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class DockBase : ViewBase, IDock
    {
        private INavigateAdapter _navigateAdapter;
        private IList<IView> _views;
        private IView _currentView;
        private IView _defaultView;
        private IView _focusedView;
        private bool _isActive;
        private IList<IDockWindow> _windows;
        private IDockFactory _factory;
        private double _proportion = double.NaN;
        private bool _isCollapsable = true;

        /// <summary>
        /// Initializes new instance of the <see cref="DockBase"/> class.
        /// </summary>
        public DockBase()
        {
            _navigateAdapter = new NavigateAdapter(this);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IList<IView> Views
        {
            get => _views;
            set => this.RaiseAndSetIfChanged(ref _views, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IView CurrentView
        {
            get => _currentView;
            set
            {
                this.RaiseAndSetIfChanged(ref _currentView, value);
                this.RaisePropertyChanged(nameof(CanGoBack));
                this.RaisePropertyChanged(nameof(CanGoForward));
                _factory?.SetFocusedView(this, value);
            }
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IView DefaultView
        {
            get => _defaultView;
            set => this.RaiseAndSetIfChanged(ref _defaultView, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IView FocusedView
        {
            get => _focusedView;
            set => this.RaiseAndSetIfChanged(ref _focusedView, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool IsActive
        {
            get => _isActive;
            set => this.RaiseAndSetIfChanged(ref _isActive, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public bool CanGoBack => _navigateAdapter.CanGoBack;

        /// <inheritdoc/>
        [IgnoreDataMember]
        public bool CanGoForward => _navigateAdapter.CanGoForward;

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IList<IDockWindow> Windows
        {
            get => _windows;
            set => this.RaiseAndSetIfChanged(ref _windows, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public IDockFactory Factory
        {
            get => _factory;
            set => this.RaiseAndSetIfChanged(ref _factory, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public double Proportion
        {
            get => _proportion;
            set => this.RaiseAndSetIfChanged(ref _proportion, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool IsCollapsable
        {
            get => _isCollapsable;
            set => this.RaiseAndSetIfChanged(ref _isCollapsable, value);
        }

        /// <inheritdoc/>
        public virtual void GoBack()
        {
            _navigateAdapter.GoBack();
        }

        /// <inheritdoc/>
        public virtual void GoForward()
        {
            _navigateAdapter.GoForward();
        }

        /// <inheritdoc/>
        public virtual void Navigate(object root)
        {
            _navigateAdapter.Navigate(root, true);
        }

        /// <inheritdoc/>
        public virtual void ShowWindows()
        {
            _navigateAdapter.ShowWindows();
        }

        /// <inheritdoc/>
        public virtual void ExitWindows()
        {
            _navigateAdapter.ExitWindows();
        }

        /// <inheritdoc/>
        public virtual void Close()
        {
            _navigateAdapter.Close();
        }
    }
}
