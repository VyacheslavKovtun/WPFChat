   M S B A M L   `   `   `  ����E  AWPFChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFChatApp.UserControlsWPFChatApp.UserControls  5      .    (WPFChatApp.UserControls.UserControlLogIn   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WPFChatApp.UserControls     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � ���	#FF05191F.+�5   
   �� $��Center=�6   $��Center=�62   $	��200��6M   .+�5      �� -   5         ��Name$ NameTB��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Name(let empty if you log in)��6&   
�������$��15q�6x   .��6�   ��5      �� 5       �� Path$
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6*   .��5       5      �� 5      -   5        $ LoginTB��5      $ Login��6'   
�������$��15q�6a   .��6m   ��5      �� 5      $
 Name�6   $ PropertyChanged=�6*   .��5        5!      G� 5%      -   5         G�Name$ PasswordBox��5%      $ Password��6/   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . 
�������$��15q�6�   �� 5)      -   5         ��Name$ LogInBtn��5)      $	��150��6'   ���	#FF003544���	#FF041C23
�������$��15q�6u   .��6�   
Continue5+      5-      "  FontAwesome.WPF.ImageAwesome  5.   
   -   5        	  Name$	 LoadingIcon��5.      
   Icon$
 Refresh=�6/      Spin . $��70��6J   $��70��6U      
Foreground
 �����$y�Hidden=�6w   5/      50      