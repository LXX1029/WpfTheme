   M S B A M L   `   `   `  ���� \  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType �� Property �� Value    TabControl.Static.Background ! TabControl.Pressed.Background % !TabControl.Static.ForegroundColor �� 
TargetType �Name J� SnapsToDevicePixels-    'System.Windows.Input.KeyboardNavigation    TabNavigation	 � ColumnDefinitions
 ��Name � RowDefinitions ��Name ��Name K� IsItemsHost    TabIndex K� ZIndex ��Name    DirectionalNavigation ��Name �� Triggers P� Property P� Value �� 
TargetName " TabControl.Disabled.Foreground �� 	Resources  FocusVisual ��Name �� Orientation �� CornerRadius �� RelativeSource �� AncestorType  AccentContentPresenter14 ]� 
Conditions �� Property  �� Value! � Offset" � Color ( $TabItem.ItemsviewSelected.Background# �� Source % !TabItem.ItemsviewHover.Background % !TabItem.ItemsviewHover.Foreground 	 AccentTabItem 
 Accent.LinearGradientBrush  Accent.DarkBrush$ �� EndPoint% �� 
StartPoint  AccentTabControl  ForegroundBrush  Disabled.ForegroundColor& �� BasedOn�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml        �� $8 2/WpfThemes;component/OfficeThemeStyles/Colors.xaml?��� $; 5/WpfThemes;component/OfficeThemeStyles/TextBlock.xaml?��� $@ :/WpfThemes;component/OfficeThemeStyles/CommonControls.xaml?�%  '��       7   7  7  7  7  7  7  7  7  7  &		 �    7  7 
 7  &	 �	    7   7  7  7  7 	 �� " ��.���  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 2q���  �@J�SnapsToDevicePixels . ��  � �� �� " ��.R�� $ templateRoot��}�.  . $ Local=�	 �� $
 ColumnDefinition0���� $
 ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+��� $ headerPanel��$��0�� . $��0q�$��0��$ 1��$ 1���� $ contentPanel��#��z��#��z��#��z��$��0��$ 	Contained=�$��1��$ 2��$ Local=�._��� $ PART_SelectedContentHost��$��SelectedContent��#��z��# z  P�  � {� .  . ��� $ templateRoot��8   � �� ���� '��       " ��.���  �@�FocusVisualStyle8  ��  � ��$	 0,0q���  � �� �� " ��.R��� $
 grid��$ 
Horizontal=�.+��� $��Border��8�� $��2q�$��0,0,2,0q�$ 2,2,0,0������ *BorderBrush+ �� $ 
TabControlL�._��  �� �� $
��auto �.+��� $ cp��#��z��#���  �� $ borderBottom��$��1��
������ $��0,0,0,-2q�$��2q� ]�  ��  �@��
IsSelected  . ��  �@J�IsMouseOver  . ./��� $ Border�� � �� �� .��� � $! 0Q�" �� 8#  � $	! 0.5Q�" �� 8#  ]�  ��  �@��
IsSelected  .  ��  �@J�IsMouseOver  . ./��� $ Border��8   � ���� $ cp��8 	  � ��P�  �@��
IsSelected . . ��� $ Border�� � ��$ 2,2,2,0q��� $ Border�� �� *
Background+ �� $ 
TabControlL� � ���� $ borderBottom�� �� *
Background+ �� $ 
TabControlL� � ���� " ��.���  �@�FocusVisualStyle8   ��  � ��$	 0,0q���  � �� �� " ��.R��� $
 grid��$ 
Horizontal=�.+��� $��Border��8�� 8�� $��2q�$��0,0,2,0q�$ 2,2,0,0��._��  �� �� $
��auto �.+��� $ ContentSite��#��z��#���  �� $ borderBottom��$��1��
������ $��0,0,0,-2q�$��2q� ]�  ��  �@��
IsSelected  .  ��  �@J�IsMouseOver  .  ./���  � �� �� $$ 0.5,1&�$% 0.5,0&�.��� $" #434244��� $" #434244��$! 1Q�� $" #434244��$	! 0.5Q�� $" #434244��$
! 0.52Q�P�  �@��
IsSelected . . ��� $ Border�� � ��$ 2,2,2,0q��� $ Border�� �� *
Background+ �� $ 
TabControlL� � ���� $ borderBottom�� �� *
Background+ �� $ 
TabControlL� � ���� " ��.���  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��8   ��  � ��8  ��  � ��$ 2q���  � ��8  ��  �@J�SnapsToDevicePixels . ��  � �� �� " ��.R�� $ templateRoot��}�.  . $ Local=�	 �� $
 ColumnDefinition0���� $
 ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+��� $ headerPanel��$��0�� . $��0q�$��0��$ 1��$ 1���� $ contentPanel��#��z��#��z��#��z��$��0��$ 	Contained=�$��1��$ 2��$ Local=�._��� $ PART_SelectedContentHost��$��SelectedContent��#��z��# z  P�  � {� .  . ��� $ templateRoot��8   � �� ���� '��       " ��8&  