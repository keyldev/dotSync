   M S B A M L   `   `   `  ����D  @sharpSync, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:sharpSync.UI.FTPsharpSync.UI.FTP  5      A%clr-namespace:sharpSync.UI.AdditionalsharpSync.UI.Additional  5          sharpSync.UI.FTP.ShareFTP   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:sharpSync.UI.FTP     5      <
Additional%clr-namespace:sharpSync.UI.Additional     5        N� Title$  ShareFTP��5	      $��610.081��6    � 	Resources 5
         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 bSetData �� 
TargetType �� 
TargetType	 ��Name
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%<  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#7500A4D4��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#50C4E5F6��6<   �� 5   
   $ 	#502C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6!   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� $	 border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5*      �� $
 contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver . . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � �� . . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {� .  . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5D      � .+�5E   
   �� -   5         ��Name$ tbFTPAddress��5E      $
��Left=�6(   $��29��6C   $��62,8,0,0q�6O    �� TextWrapping$
 Wrap=�5F      $��ftp://��6&   $	��Top=�64   $	��716��6L   $��Center=�5G      ���	#FF1A1B23
�������$��0q�5H      ��5G   4   Z� .��5H   &    5I      ��%^   '��       �� 5J      " ��6   .�5K      ��  �@��CornerRadius$ 5��65   5L      5M      .��6!   5N      �� 5O   
   -   5         ��Name$ bGoBack��5O      $��<��6"   $
��Left=�61   $��4,10,0,0q�6L   $	��Top=�6^   $��27��6v   $��0q�5P      $��24��6%   
����������	#FF5D5D5D$��16(�6[   $��Center=�5Q      $��Center=�65   $��0,0,0,2q�6W   #��� 
 6i   ��5O   �   Z�  5R      ��%^   '��       �� 5S      " ��6   .�5T      ��  �@��CornerRadius$ 3��65   5U      5V      5W      �� 5X   
   -   5        $ 
bGoForward��5X      $��>��6%   $
��Left=�64   $��	32,10,0,0q�6O   $	��Top=�6b   $��27��6z   $��0q�5Y      $��24��6!   
����������	#FF5D5D5D$��16(�6W   $��Center=�5Z      $��Center=�61   $��0,0,0,2q�6S   #��� 
 6e   ��5X   �   Z�  5[      ��%^   '��       �� 5\      " ��6   .�5]      ��  �@��CornerRadius$ 3��65   5^      5_      5`      � 5a   
   $��
4,88,459,0q�6   $	��520��6#   $	��Top=�60   .+�5b      �� $��+��6   $
��Left=�6    $	��Top=�6;   $��	126,5,0,0q�6S   $��72(�6f   $	��123��6t   ���	#FFBFBFBF6�   �� 5c      -   5        $
��Left=�5c      $��	0,5,0,392q�64   $	��316��6G   $ 10R�5d      $��2��6*    �� RadiusX$ 10��6>    �� RadiusY$ 10��6K    �� StrokeDashCap$ Round=�6X   
������� J� 	AllowDrop . ���	#4C8787875e   <   �� 5f      $
��Left=�6   $	��346��66   $��	0,133,0,0q�6C   $	��Top=�6V   $	��316��6n   $��Hidden=�6z   .��5g      �� -   5         ��Name$ 	filesList��5g      
���   �$��0q�6F   $
��auto��6Z   $
��auto��6h   5h      �� 5i      -   5        $ bUploadFiles��5i      $��Загрузить��6+   $��Center=�6?   $��Bottom=�6\   $	��157��6w   $��	1,0,163,2q�6�   $��36��5j      $��0q�5k      ���	#FF00A4D4$��14(�6W   
�������#��� 
 6x   ��6)   Z�  5m      ��%^   '��       �� 5n      " ��6   .�5o      ��  �@��CornerRadius$ 8��69   5p      5q      5r      �� 5s      -   5        $ 
bClearList��5s      $
��Left=�6)   $��161,482,0,0q�6D   $	��Top=�6Y   $	��155��6q   $��0q�5t      $��36��6%   
����������	#FF00A4D4$��16(�6[   $��Center=�5u      $��Center=�65   $��0,0,0,2q�6W   #��� 
 6i   ��5s   }   Z�  5w      ��%^   '��       �� 5x      " ��6   .�5y      ��  �@��CornerRadius$ 3��69   5z      5{      .��5|      � $��29��6   $	��150��6#   .+�5}      �� $��Right=�6   $��18��68   $��Center=�6D   $��20��6_   $<��6/sharpSync;component/Assets/icons/interface/bucket.png��5~      $��0,6,5,5q�6Y   �� 5      $��Очистить��6   $��Center=�6/   $��0q�6L   $��Center=�6W   $��71��6r   
�������$��14(�6�   5�      5�      5�      �� 5�   
   $��1q�6   $
��Left=�6%   $	��519��6@   $��
325,88,0,0q�6M   $	��Top=�6a   $��5��6y   ���	#FF383838���	#FF383838 �� CornerRadius$ 2��5�      � 5�   
   $
��Left=�6   $	��519��6*   $��
335,88,0,0q�67   $	��Top=�6K   $	��449��6c   .+�5�      �� -   5         ��Name$ files��5�      $	��519��6&   $��0q�63   $	��Top=�6>   ��6V   �� ��6n   Z� ��6�   Z�  �� View 5�      �� 5�      P�5�      �� 5�      $��Файл��6-    �� Width$	 200��6;    �� CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� -	   5         �� Orientation$ 
Horizontal=�5�   5   $��36��6N   .+�5�   .   �� $��32��64   $��32��6?   ��6K   �� *Type+�� 5�   .   
�������$
��12,0q�6d   ��6N   �� *Name+6d   5�   +   5�   '   5�      �� 5�      $��Размер��6-   $ 50��6=    �� DisplayMemberBinding 6H   �� *
FileSize+�� 5�      $��Дата создания��6-   $	 200��6D    6P   �� *Date+5�      5�      5�      �� 5�   
   -
   5        $ tbConnectIP��5�      $
��Left=�6'   $��29��6B   $��6,42,0,0q�6N   $
 Wrap=�5�      $��	127.0.0.1��6!   $	��Top=�62   $	��168��6J   $��Center=�5�      ���	#FF1A1B23
�������$��0q�5�      ��5�   /   Z� .��5�   G    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��65   5�      5�      .��6!   5�      �� 5�   
   -   5        $ bSetData��5�      $
��Left=�6#   $��
693,42,0,0q�6>   $	��Top=�6R   $��85��6j   $��0q�5�      $��29��6!   
����������	#FF00A4D4$��16(�6W   $��Center=�5�      $��Center=�61   $��0,0,0,2q�6S   #��� 
 6e   ��5�   u   Z�  5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 3��65   5�      5�      .��5�      � $��29��6   $��85��6   .+�5�      �� $��Right=�6   $��18��64   $��Center=�6@   $��20��6[   $=��7/sharpSync;component/Assets/icons/interface/go_find.png��5�   $   $��0,6,5,5q�6e   �� 5�      $��GO��6   $��Center=�6%   $��0q�6B   $��Center=�6M   $��34��6h   
�������$��14(�6�   5�      5�      �� 5�   
   -   5        $ tbPort��5�      $
��Left=�6"   $��29��6=   $��
179,42,0,0q�6I   $
 Wrap=�5�      $��21��6!   $	��Top=�6+   $	��168��6C   $��Center=�5�      ���	#FF1A1B23
�������$��0q�5�      ��5�   /   Z� .��5�   C    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��65   5�      5�      .��6!   5�      �� 5�   
   -   5        $ tbLogin��5�      $
��Left=�6#   $��29��6>   $��
352,42,0,0q�6J   $
 Wrap=�5�      $��login��6!   $	��Top=�6.   $	��168��6F   $��Center=�5�      ���	#FF1A1B23
�������$��0q�5�      ��5�   /   Z� .��5�   "    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��65   5�      5�      .��6!   5�      �� 5�   
   -   5        $ 
tbPassword��5�      $
��Left=�6&   $��29��6A   $��
525,42,0,0q�6M   $
 Wrap=�5�      $��password��6!   $	��Top=�61   $	��163��6I   $��Center=�5�      ���	#FF1A1B23
�������$��0q�5�      ��5�   /   Z� .��5�   "    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��65   5�      5�      .��6!   5�      5�      5�      