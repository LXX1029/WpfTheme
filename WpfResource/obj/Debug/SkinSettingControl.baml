   M S B A M L   `   `   `  ����D  @WpfThemes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfThemes	WpfThemes  5      "    WpfThemes.SkinSettingControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:WpfThemes     5      .��5	      � .+�5
   
   d� -   5          d�Name$  chkTheme��5
       d� IsThreeState .  $��皮肤��6>      AccentToggleButtonSkin#���   6K   6~   � 5   
   -   5         �Name$ popup��5      $
��Fade=�6!    � 	StaysOpen .  $
��Left=�5       � HorizontalOffset$ -1��6#    � AllowsTransparency .  � PlacementTarget 5   8   ��  �� ElementName$ chkTheme����6{   �� *	IsChecked+$ chkTheme�� �� UpdateSourceTrigger$ PropertyChanged=�.��5      � $��2q�6   .+�5      F� -   5        	 F�Name$	 
pathBorder��5        Item.SelectedActive.Border#���  6+   $��2��6a   
 K� ZIndex$
 0��6u    J� SnapsToDevicePixels . ��5      �� *
Background+$ lbSkins��5"      �� 5#      -   5         ��Name$ lbSkins��5#        AccentSkinSetListBox#���  6L   ��6+   �� *
SkinList+5$      5%      5&      5(      5)      