﻿using InputKit.Shared;
using System.Collections;
using System.Collections.ObjectModel;

namespace UraniumUI.Material.Controls;
public partial class DataGrid
{
    public IList ItemsSource { get => (IList)GetValue(ItemsSourceProperty); set => SetValue(ItemsSourceProperty, value); }

    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(DataGrid), propertyChanged: (bo, ov, nv) => (bo as DataGrid).OnItemSourceSet(ov as IList, nv as IList));

    public DataTemplate CellItemTemplate { get => (DataTemplate)GetValue(CellItemTemplateProperty); set => SetValue(CellItemTemplateProperty, value); }

    public static readonly BindableProperty CellItemTemplateProperty =
        BindableProperty.Create(nameof(CellItemTemplate), typeof(DataTemplate), typeof(DataGrid), defaultValue: null,
            propertyChanged: (bo, ov, nv) => (bo as DataGrid).Render());

    public Color LineSeperatorColor { get => (Color)GetValue(LineSeperatorColorProperty); set => SetValue(LineSeperatorColorProperty, value); }

    public static readonly BindableProperty LineSeperatorColorProperty =
        BindableProperty.Create(nameof(LineSeperatorColor), typeof(Color), typeof(DataGrid), defaultValue: Colors.Gray,
            propertyChanged: (bo, ov, nv) => (bo as DataGrid).OnPropertyChanged(nameof(LineSeperatorColor)));

    public IList<DataGridColumn> Columns { get => (IList<DataGridColumn>)GetValue(ColumnsProperty); set => SetValue(ColumnsProperty, value); }

    public static readonly BindableProperty ColumnsProperty =
        BindableProperty.Create(nameof(Columns), typeof(IList<DataGridColumn>), typeof(DataGrid), defaultValue: new ObservableCollection<DataGridColumn>(),
            propertyChanged: (bo, ov, nv) => (bo as DataGrid).OnColumnsSet((IList<DataGridColumn>)ov, (IList<DataGridColumn>)nv));

    public bool UseAutoColumns { get => (bool)GetValue(UseAutoColumnsProperty); set => SetValue(UseAutoColumnsProperty, value); }

    public static readonly BindableProperty UseAutoColumnsProperty =
        BindableProperty.Create(nameof(UseAutoColumns), typeof(bool), typeof(DataGrid), defaultValue: false,
            propertyChanged: (bo, ov, nv) => (bo as DataGrid).SetAutoColumns());

    public IList SelectedItems { get => (IList)GetValue(SelectedItemsProperty); set => SetValue(SelectedItemsProperty, value); }

    public static readonly BindableProperty SelectedItemsProperty =
        BindableProperty.Create(nameof(SelectedItems), typeof(IList), typeof(DataGrid), defaultValue: new ObservableCollection<object>(),
            defaultBindingMode: BindingMode.OneWayToSource, propertyChanged: (bo, ov, nv) => (bo as DataGrid).OnSelectedItemsSet());

    public Color SelectionColor { get => (Color)GetValue(SelectionColorProperty); set => SetValue(SelectionColorProperty, value); }

    public static readonly BindableProperty SelectionColorProperty =
        BindableProperty.Create(nameof(SelectionColor), typeof(Color), typeof(DataGrid), defaultValue: InputKitOptions.GetAccentColor(),
            propertyChanged: (bo,ov,nv)=>(bo as DataGrid).SetSelectionVisualStatesForAll());
}