   M S B A M L   `   `   `  ����E  AWPFChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFChatApp.UserControlsWPFChatApp.UserControls  5      1    +WPFChatApp.UserControls.UserControlContacts   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WPFChatApp.UserControls     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � ���	#FF05191F � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   .+�5      � .+�5      �� $��Center=�6   
�������$��20(�6H   .��6V   Your Contacts6e   �� 5      -   5         ��Name$ WriteToContact��5      $��1��61     MaterialDesignIconButton#��[ 6A   $��0 0 35 0q�6s    � ToolTip$ Write��6�   $��25��6�   $��25��6�   $��Right=�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Message=�6.   
�������6=   5      �� 5!      -   5        $ DeleteContact��5!      $��2��60   #��[ 6@   $ Delete��6r   $��25��6�   $��25��6�   $��Right=�6�   ��6�   �� *DeleteContactCommand+��6�   �� *SelectedContact+.��5"        $ Delete=�6.   
�������6<   5#      5$      �� 5%      -   5         ��Name$ 
ContactsLB��5%      ��6*   �� *
Contacts+ �� SelectedItem 6K   �� *SelectedContact+��5&      �� 5'      .R�5(      ��  ��Name$ CBorder��6!   	 �� Padding$	 8q�62   $��0 0 0 1q�6>     MaterialDesignDivider#���  6X   ._�5)      � $
��1020��6#   
 � ColumnDefinitions
 5*   "   �� 5+   &   $��8* �67   �� 5,   &   $��* �67   �� 5-   &   $��* �67   .+�51   "   �� $��12 0 0 0q�6-   $��0��6?   $��Center=�6O   .+�52   &   �� $	��500��60   $��5q�6<   $��17(�6a   $��Center=�6o   $��Center=�6�    �� TextAlignment$ Center=�6�   
���������6G   �� *
Nickname+6�   53   #   54      55       �� Triggers 57      �� 58       �� Value$
 True��6P    �� Binding 6*   �� *IsSelectedContact+.a�59   "   ��  �� 
TargetName$ CBorder��6)     MaterialDesignSelection �� Value# �  6T    �� Property � ��5:      5<      5>      5?      �� 5C   
   $��1��6   .+�5D      � .+�5E      �� $��Center=�6   
�������$��20(�6H   .��6V   	All Users6a   �� 5G      -   5        $ AddNewContact��5G      $��35��60   $��35��6;   #��[ 6G   $��Bottom=�6y   $��Right=�6�   $	 Add��6�   ��6�   �� *AddNewContactCommand+��6�   �� *SelectedUser+.��5H        $	 Add=�6.   
�������69   5I      5J      �� 5K      -   5        $ 
AllUsersLB��5K      ��6*   �� *
AllUsers+ 6K   �� *SelectedUser+��5L      �� 5M      .R�5N      �� $ UBorder��6!   $	 8q�62   $��0 0 0 1q�6>   #���  6X   ._�5O      � $
��1020��6#   
 5P   "   �� 5Q   &   $��8* �67   �� 5R   &   .+�5V   "   �� $��12 0 0 0q�6-   $��0��6?   $��Center=�6O   $	��500��6l   .+�5W   &   �� $��5q�60   $��17(�6U   $ Center=�6c   $��Center=�6z   $��Center=�6�   
���������6;   �� *
Nickname+6�   5X   #   5Y      5Z       5\      �� 5]      $
 True��6M    6*   �� *IsSelectedUser+.a�5^   "   �� $ UBorder��6)   # �  6T    � ��5_      5a      5c      5d      5f      5g      