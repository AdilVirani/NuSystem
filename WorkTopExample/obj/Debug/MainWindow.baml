   M S B A M L   `   `   `  ����E  ARadialMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM5clr-namespace:RadialMenu.Controls;assembly=RadialMenuRadialMenu.Controls  5   	   I EWorkTopExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:RadialMenuDemo.UtilsRadialMenuDemo.Utils 5   	   M IWpfControlLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI7clr-namespace:CustomToolTip;assembly=WpfControlLibrary1CustomToolTip 5   	   M IWpfControlLibrary2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfControlLibrary2;assembly=WpfControlLibrary2WpfControlLibrary2 5   	      WorkTopExample.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   JControls5clr-namespace:RadialMenu.Controls;assembly=RadialMenu     5   	   9
Converters"clr-namespace:RadialMenuDemo.Utils     5   	   M	myToolTip7clr-namespace:CustomToolTip;assembly=WpfControlLibrary1     5   	   [WpfControlLibrary2<clr-namespace:WpfControlLibrary2;assembly=WpfControlLibrary2     5   	   -   5        {�.   J� IsManipulationEnabled  .  J� 	AllowDrop .  � WindowState$ 	Maximized=�5   	    � Title$ 
MainWindow��5   	    � 	Resources 5   
    �� Source�� 5      $ Utils/Icons.xaml?�6!   %    .��5   
   �� .+�5   
   �� -   5         ��Name$ MyCanvas��5      
�������$��15000��6�   $��10000��6�    5      /   )RadialMenu.Controls.RadialMenuCentralItem �� 
TargetType �� BasedOn	 �� Property
 �� Value(   "RadialMenu.Controls.RadialMenuItem��%>  '        7 '  �     7 �� 5      "  6   8   .�5      �� 	 � ��

 �����63   �� 5!      	 � ��

 ��  �64   �� 5#      	 � ��$
 4q�68   �� 5%      	 � ��$
 64��6.   �� 5'      	 � ��$
 64��6/   5(      �� 5)      "  6   8   .�5,      �� 	 � ��

 �����63   �� 5.      	 �@ Padding$
 2Q�60   �� 50      	 �@ InnerRadius$
 40Q�64   �� 52      	 �@ OuterRadius$	
 150Q�64   �� 54      	 �@ ContentRadius$
 85Q�66   �� 56      	 �@ EdgeBackground

 ��  �67   �� 58      	 �@ EdgePadding$
 7Q�64   �� 5:      	 �@ EdgeInnerRadius$	
 130Q�68   �� 5<      	 �@ EdgeOuterRadius$	
 145Q�68   �� 5>      	 �@ ArrowBackground

 ��� �68   �� 5@      	 �@ ArrowRadius$	
 138Q�64   5A      5B      z�5C      �� 5D      -   5        st��5D   !   .+�5G      $   RadialMenu.Controls.RadialMenu  -   5          Name$ MyRadialMenu��5G   "      IsOpen 68   �� *IsOpen+   CentralItem 5J        5K      ��65   �� *CloseRadialMenu+.��5L      �� $��25��6$   $��25��6/   ��5M      !� 5N   "      appbar_close !� Visual# [  6.   5P      5Q         Content. 5T        ��6*   �� *Test1+.��5U      �  � Orientation$ Vertical=�6    .+�5V      �� $��25��6$   $��25��6/   ��5W      !� 5X   "     
appbar_add# [ 6.   5Z      �� 5[      $��14(�6$    �� TextAlignment$ Center=�62   �� 6J   $�Add Text��6N   6a   5\      5]        5_      ��6*   �� *Test2+.��5`      � $ Vertical=�6    .+�5a      �� $��25��6$   $��25��6/   ��5b      !� 5c   "     appbar_edit# [ 6.   5e      �� 5f      $��14(�6$   $ Center=�62   �� 6J   $�Add Writing��6N   6d   5g      5h        5j      ��6*   �� *Test3+.��5k      � $ Vertical=�6    .+�5l      �� $��23��6$   $��25��6/   ��5m      !� 5n   "     appbar_calculator# [ 6.   5p      �� 5q      $��14(�6$   $ Center=�62   �� 6J   $�
Calculator��6N   6c   5r      5s        5u      ��6*   �� *Test4+.��5v      � $ Vertical=�6    .+�5w      �� $��20��6$   $��25��6/   ��5x      !� 5y   "     appbar_delete# [ 6.   5{      �� 5|      $��14(�6$   $ Center=�62   �� 6J   $�Delete��6N   6_   5}      5~        5�      ��6*   �� *Test5+.��5�      � $ Vertical=�6    .+�5�      �� $��20��6$   $��25��6/   ��5�      !� 5�   "     appbar_page# [ 6.   5�      �� 5�      $��14(�6$   $ Center=�62   �� 6J   $�New Page��6N   6a   5�      5�        5�      -   5        ��5�   *   �� *Test6+.��5�      � $ Vertical=�6    .+�5�      �� $��19��6$   $��26��6/   ��5�      !� 5�   "     appbar_upload# [ 6.   5�      �� 5�      $��14(�6$   $ Center=�62   �� 6J   $�Upload Image��6N   6e   5�      5�      5�      5�      5�      5�      