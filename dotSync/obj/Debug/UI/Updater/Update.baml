   M S B A M L   `   `   `  ����D  @sharpSync, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:sharpSync.UI.UpdatersharpSync.UI.Updater  5      !    sharpSync.UI.Updater.Update   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:sharpSync.UI.Updater     5      -   5          N� Title$  Update��5	      $	��240��6   $	��240��6#    � 	Resources 5         ProgressBar.Progress �� Color  ProgressBar.Background  ProgressBar.Border  downloadProgressBar �� 
TargetType �� Property �� Value �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle��%0  &	        &	 #     &	 F     &	 i     7   7  7  �� 5   
   $ 	#FF06B025��67   �� 5   
   $ 	#FFE6E6E6��69   �� 5   
   $ 	#FFBCBCBC��65   �� 5   
   " �6,   .�5      ��  � ��8   6+   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��$ 1q�60   �� 5       � �� 5      �� 5      " �6&   .R�5      � $ TemplateRoot��6    5        5   "   CommonStates��.	 5   &     Determinate��62     5   &   Indeterminate��.
 5   *   �� $ Forever��65   .��5   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   $ 	Animation��6�   .\�5   2     $ 0��6G   $
 0.25Q�6S     5   2   $ 0:0:1��6G   $
 0.25Q�6W     5    2   $ 0:0:2��6G   $
 0.25Q�6W   5!   /   *� 5"   .   $' !(UIElement.RenderTransformOrigin)�6K   $ 	Animation��6�   .'�5#   2     $ 0��6F   $ -0.5,0.5&�6R     5$   2   $ 0:0:1��6F   $ 0.5,0.5&�6V     5%   2   $ 0:0:2��6F   $ 1.5,0.5&�6V   5&   /   5'   +   5(   '   5)   #   .+�5+      �� #��z��6%   #��z��6Q   #��z��6�   �� 5,      $ 
PART_Track��6(   � 5-      $ PART_Indicator��6#   }�. $
��Left=�6O   .+�5.   "   �� $ 	Indicator��6,   #��z��6?   �� 5/   "   $ 	Animation��6,   #��z��6?   $ 0.5,0.5&�6c   z�50   &   V� 51   *   .~�52   .   �� �� 53   .   �� 54   .   T� 55   .   56   +   58   #   59      5:       5;      P� 5<       �@�Orientation$ Vertical=�6=   . �5=   "   �� $ TemplateRoot��6D    �@�LayoutTransform 5>   &   �� 5?   *   $	 -90Q�6:   5A   #   5B      P� 5C       �@�IsIndeterminate . . �5D   "   �� $ 	Indicator��6?    � y�$ 	Collapsed=�6V   5E      5G      5I      5J      5K      .��5M      � .+�5N   
   �� -   5         ��Name$ percentLabel��5N      $
��Left=�6;   $��	0,189,0,0q�6V   $	��Top=�6i   $��0q�6�   
�������$	��240��6�   ��6&   �� 6�   � 5O   
   -   5         �Name$ downloadProgressBar��5O      $
��Left=�63   $��10��6N   $��	0,220,0,0q�6Z   $	��Top=�6m   $	��240��6�   $��0q�5P      ���	#FF00FFF3��5O   �   Z� ��6�   Z�  � Value 5Q      �� *DownloadProgressBarValue+ �� UpdateSourceTrigger$ PropertyChanged=��� 5R   
   $
��Left=�6   $��71��6+   $	��Top=�67   $	��185��6O   $*��$/sharpSync;component/Assets/logo.png��6[   $��	29,69,0,0q�6�   5T      5U      