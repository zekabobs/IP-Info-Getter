   M S B A M L   `   `   `  ����I  EIp Info Getter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:IpInfoGetter.DictionariesIpInfoGetter.Dictionaries  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxNormalBorderBrush  �� Color ! ComboBoxNormalBackgroundBrush # ComboBoxDisabledForegroundBrush # ComboBoxDisabledBackgroundBrush  ComboBoxDisabledBorderBrush �� 
TargetType   ComboBoxToggleButtonTemplate � ColumnDefinitions �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value  ComboBoxFlatStyle
 �� 
TargetType �� 	ClickMode d� 	IsChecked �� Path �� RelativeSource �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate �� 
IsReadOnly �� 
IsReadOnly � AllowsTransparency �� IsDropDownOpen J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight-   'System.Windows.Input.KeyboardNavigation    DirectionalNavigation  EasyCbStyle  	EasyStyle �� BasedOn �� Triggers�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1local'clr-namespace:IpInfoGetter.Dictionaries  5      %�  &	        &	 !     &	 ?     &	 ]     &	 {     (�� �     5	      * SystemColors.HighlightBrushKey+)&	 �     7   7  7  7  7  7  7  &	 &    7  7   7  &	 �    7  �� 5      $  #e3e9ef��68   �� 5      $
  #fff��6<   �� 5      $
  #888��6>   �� 5      $
  #eee��6>   �� 5      $
  #888��6:   �� 5	      $  #5F7D95 ��6J   �� 5      " d�6   .R�5   
   �  5      �� 5      �� 5      $��20 �6#   .+�5      �� $��Border��6)   $��2��6   8��  $ 0��5      $��
1, 1, 1, 1q�6    8�� 5      �� 5      $��ButtonBorder��6L   $��1��6   $��
1, 1, 1, 1q�6%   ���#444$ 
0, 0, 0, 0��5      $��
0, 0, 0, 0q�6)   8�� 5      F� 5      $��Arrow��6   $��1��6    =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=�5      ���#444$��Center=�5      5       5   
   P� 5       �@J�IsMouseOver . . �5       �� $ ButtonBorder��65    � ��
	 �����6O   5!      P� 5"       �@d�	IsChecked$
 TrueY�68   . �5#      �� $ ButtonBorder��65    � ��
	 �����6O   �� 5$      $ Arrow��6/    � ��	 �	#FF8D979E6B   5%      P� 5&       � {� .  . �5'      �� $ Border��65   8	   � ��6I   �� 5(      $ ButtonBorder��65   8	   � ��6O   �� 5)      $ ButtonBorder��67   8	   � ��6Q   �� 5*      8	   � ��6;   �� 5+      $ Arrow��6/    � ��	 �#9996B   5,      5.      �� 50      "
 ��6'   .�51   
   ��  �@J�SnapsToDevicePixels	 . 6:   �� 52   
    �@�OverridesDefaultStyle	 . 6C   �� 53   
    � ��$
	 Auto=�6G   �� 54   
    � ��$
	 Auto=�6E   �� 55   
    � ��	 . 6:   �� 56   
    � ��
	 �   �63   �� 57   
    �@�FocusVisualStyle	 6>   Z� �� 58   
    � ��	 59      �� 5:      " ��6"   .R�5;      � .+�5<      d� $��ToggleButton��6'   $��2��6;   $ Press=�5=      |�.  8��   5>      �� $ IsDropDownOpen� �� *TemplatedParent+$ TwoWay=�5?      �� 5A      $��ContentSite��6+   $��5, 3, 23, 3q�6>    .  $
��Left=�5B      $��Center=�6:   #��z 5C      #��z 5D      #��z��5E      �� 5F      $��PART_EditableTextBox��6"   $��3, 3, 23, 3q�6>   # z 5G      $y�Hidden=�5H      
������ $
��Left=�5I      $��Center=�61   |�. .��5J   (   ��5K      �� 5L   "   " ��62   .R�5M   &   �� $��PART_ContentHost��6-   |�.  6E   5N   #   .��5O   0   5P      � 5Q      $��Popup��6    $��Bottom=�6-   |�.   . #��z 5S      $��Slide=�5T      .��5U      � $��DropDown��6#    . #��z 5V      #��z 5W      .+�5X   "   �� $��DropDownBorder��6)   
�������$��
0, 1, 0, 0q�6R   $ 0��5Y      $��1,1,1,1q�6*   8�� 5Z      �� 5[   "   $��4q�6/    . .��5\   &   �� $ 	Contained=�65   5]   #   5^      5_      5`       5a      P� 5b       �@��HasItems .  . �5c      �� $ DropDownBorder��6K    � ��$	 95��6g   5d      P� 5e       � {� .  . �5f      �� 8	   � ��6G   5g      P� 5h       �@��
IsGrouping . . �5i      ��  � ��	 .  6N   5j      P� 5k       �@��
IsEditable . . �5l      ��  �@  	IsTabStop	 .  6M   �� 5m      $ PART_EditableTextBox��6E    � y�$	 Visible=�6g   �� 5n      $ ContentSite��6E    � y�$	 Hidden=�6^   5o      5q      5s      5t      �� 5w      "
 ��6    8    5x   
   P� 5y       �@��
IsSelected . . �5z      ��  � ��	 �#8ac0f26/   �� 5{       � ��	 �#8ac0f260   5|      P� 5}       �@J�IsMouseOver . . �5~      ��  � ��	 �#8ac0f267   �� 5       � ��	 �#8ac0f260   5�      5�      5�      