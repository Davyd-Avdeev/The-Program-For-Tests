   M S B A M L   `   `   `  ����B  >Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProgramProgram  5   	   !    Program.PasswordInputWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Program     5   	   -   5          � Title$  Ввод пароля��5   	   $	��150��6   $	��300��6-   $	��150��6<   $	��300��6L   $	��150��6[   $	��300��6h    � Icon$ IconForProgram.png��6t   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ #f5f5dc��6    � Offset$ 0Q�6/   � 5      $ #42aaff��6   $ 1Q�6/   5      .+�5   
   �� -   5         ��Name$ tbxPass��5      $
��Left=�6#   $��23��6>   $��	10,10,0,0q�6J    �� TextWrapping$
 Wrap=�6]   
�������$!��Введите пароль��6�   $	��Top=�6�   $	��250��6�   6�   �� 5   
   -   5         ��Name$ btnExit��5      $��
Выход��6"   $��Center=�62   $��Bottom=�6O   $��
0,0,-85,20q�6j   $	��150��6~   $	��100��6�   $��50��6�   $��75��6�      ButtonTemplate#��[  6�   $��18(�6�   $��Normal$�6�   6  �� 5   
   -   5        $ btnEnter��5      $��Ввод��6#   $��Center=�62   $��Bottom=�6O   $��	0,0,85,20q�6j   $	��150��6}   $	��100��6�   $��50��6�   $��75��6�   #��[  6�   $��18(�6�   $��Normal$�6�   6  5      5      