   M S B A M L   `   `   `  ����E  AWPFChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFChatApp.UserControlsWPFChatApp.UserControls  5   	       WPFChatApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WPFChatApp.UserControls     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $	��600��6   $
��1080��6)    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5       �� Source�� 5   
   $ MainDictionary.xaml?�6   %     � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      ��   MenuOpen#��[ 6   5      :� 5   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5      ��   	MenuClose#��[ 6   5      .��5      � 	 � ColumnDefinitions	 5   
   �� 5      ��6   �� 
 �� ElementName$
 GridMenu�� �� Path$ Width��� 5        � RowDefinitions 5"   
   �� 5#      $��60 �6   �� 5$      .+�5(   
   � -   5         �Name$ GridTop��5(      $��60��6    $��2��6,   $��0��6@   $	��Top=�6M   ���	#FF072832.+�5)      �� -   5         ��Name$ 	TopGridTB��5)      $
��Chat��6+   $��Center=�67   $��Center=�6T   ���	#FFF1F1F1$��25(�6�   5*      � 5.   
   -   5        $ GridMenu��5.      $��60��6!   $��0��6,   $��2��6<   $
��Left=�6M   ���	#FF072832.+�5/      �� .+�50      � $��75��6   .+�51      �� -   5         ��Name$ ButtonCloseMenu��51      $��60��66   $��60��6A   $	��Top=�6z   $��Right=�6�   $y�	Collapsed=�6�   ��6M   Z� ��6c   Z� .��52      '  !MaterialDesignThemes.Wpf.PackIcon  ���	#FFF1F1F1   Kind$ 	ArrowLeft=�6I   $��25��6Z   $��25��6e   53      �� 54      -   5        $ ButtonOpenMenu��54      $��60��65   $��60��6@   $	��Top=�6y   $��Right=�6�   ��6L   Z� ��6b   Z� .��55        ���	#FFF1F1F1$
 Menu=�6I   $��25��6U   $��25��6`   56      57      �� 58      $��Disabled=�6    �� SelectedItem 6Q   �� *SelectedMainMenuItem+.@�59      �� -   5         ��Name$ 
LVItemChat��59   #   
 � Tag$
 Chat��67   $��75��6B   ���	#FFF1F1F1.��5:      ��  �� Orientation$ 
Horizontal=�6%   .+�5;        $ Message=�66   $��25��6E   $��25��6P   $��10q�6\   $��Center=�6h   �� 5<      $
��Chat��6(   $��Center=�64   $��20 10q�6O   $��20(�6^   5=      5>      �� 5?      -   5        $ LVItemContacts��5?   #   $ Contacts��6;   $��75��6J   ���	#FFF1F1F1.��5@      �� $ 
Horizontal=�6%   .+�5A        $ Contact=�66   $��25��6E   $��25��6P   $��10q�6\   $��Center=�6h   �� 5B      $��Contacts��6(   $��Center=�68   $��20 10q�6S   $��20(�6b   5C      5D      �� 5E      -   5        $ LVItemSettings��5E   #   $ Settings��6;   $��75��6J   ���	#FFF1F1F1.��5F      �� $ 
Horizontal=�6%   .+�5G        $ Settings=�66   $��25��6F   $��25��6Q   $��10q�6]   $��Center=�6i   �� 5H      $��Settings��6(   $��Center=�68   $��20 10q�6S   $��20(�6b   5I      5J      5K      5L      5M      � 5Q   
   
�������$��1��6&   $��1��66   .+�5R      � -	   5        $ 	LogInGrid��5R      $y�Visible=�6&   .+�5S      .   (WPFChatApp.UserControls.UserControlLogIn  -
   5          Name$ LogInUC��5S   )   5T      � 5V      -   5        $ ChatGrid��5V      $y�Hidden=�6%   .+�5W      -   'WPFChatApp.UserControls.UserControlChat  -   5          Name$ ChatUC��5W   (   5X      � 5Z      -   5        $ ContactsGrid��5Z      $y�Hidden=�6)   .+�5[      1   +WPFChatApp.UserControls.UserControlContacts  -   5          Name$ 
ContactsUC��5[   ,   5\      � 5^      -   5        $ SettingsGrid��5^      $y�Hidden=�6)   .+�5_      1   +WPFChatApp.UserControls.UserControlSettings  -   5          Name$ 
SettingsUC��5_   ,   5`      5a      5c      5d      