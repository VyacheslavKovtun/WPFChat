   M S B A M L   `   `   `  ����E  AWPFChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFChatApp.UserControlsWPFChatApp.UserControls  5      -    'WPFChatApp.UserControls.UserControlChat   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WPFChatApp.UserControls     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � ���	#FF05191F.+�5   
   � $	��500��6    � ColumnDefinitions 5      �� 5      $	��19* �6#   �� 5      $	��66* �6#   .+�5      �� 
�������$��	0 0 1.5 0q�6,   ._�5      �� $��0��6   ���	#FF0A303C.+�5      �� -   5         ��Name$ GroupsLV��5      ��61   �� *Groups+ �� SelectedItem 6P   �� *SelectedGroup+��5      �� 5      .R�5   "   ��  ��Name$ CBorder��6)    �� Padding$ 5q�6:   $��0 0 0 1q�6F     MaterialDesignDivider#���  6`   ._�5   &   �� $��5q�60   $��16(�6Q   $��Center=�6_   $��Center=�6z    �� TextAlignment$ Center=�6�   
���������6;   �� *Name+6�   5   #    �� Triggers 5    "   �� 5!   &   	 �� Value$
	 True��6U   
 �� Binding
 62   �� *IsSelectedChat+.a�5"   *   ��  �� 
TargetName$ CBorder��61     MaterialDesignSelection �� Value# �  6\    �� Property � ��5#   '   5%      5'      �� 5)      -   5        $ ChatsLV��5)      ��60   �� *Chats+ 6N   �� *SelectedChat+��5*      �� 5+      .R�5,   "   �� $ CBorder��6)   $ 5q�6:   $��0 0 0 1q�6F   #���  6`   ._�5.   &   �� $��5q�60   $��16(�6U   $��Center=�6c   $��Center=�6~   $ Center=�6�   
���������6;   �� *
Nickname+6�   5/   #    51   "   �� 52   &   $
	 True��6U   
 62   �� *IsSelectedChat+.a�53   *   �� $ CBorder��61   # �  6\    � ��54   '   56      58      59      5:      � 5<      $��1��6    � RowDefinitions 5=      �� 5>      $
��111* �6$   �� 5?      $	��14* �6$    5A      �� 5B      $��8* �6'   �� 5C      .+�5E      �� -   5         ��Name$ MainTB��5E   ;   $��2��6   $��0��6.    �� 
IsReadOnly . 
�������$��15(�6p   �� 5F      -   5        $ MsgTB��5F      ���	#FF0A303C$��1��6@   $��0��6M   
�������6]   �� 5G      -   5         ��Name$ SendBtn��5G      $��1��6*   $��1��67   $
��Auto��6G   
�������.��6~   Send6�   5H      5I      5J      5K      