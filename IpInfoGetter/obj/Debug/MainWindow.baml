   M S B A M L   `   `   `  ����I  EIp Info Getter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:IpInfoGetterIpInfoGetter  5   	       IpInfoGetter.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:IpInfoGetter     5   	     � Title$   ��5   	   $	��270��6   $	��380��6   ���#5F7D95$	��270��5	   	   $	��490��6   $	��270��6(   $	��500��68    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5        IpInfoGetter.TimeNow   TimeNOW   Timenow��%$   &	          5   
   $  ��6(   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��25* �6   �� 5      $
��180* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      $	��25* �6   �� 5      $	��25* �6   �� 5      $
��140* �6   .+�5   
   � $��3��6   .+�5      �� -   5        ���#8ac0f25   '   �� 5      -   5          BigButtonsStyle#��[ 5      $	��Top=�5      .��5       �� .��5!      �� $��Images\more.png��6   5"      5#      �� 5$      -   5        #��[ 5$      $��Bottom=�5%      $��3��5&   .   .��5'      �� .��5(      �� $��Images\settings.png��6   5)      5*      5,      � 5-   
   $��1��6   $��2��6   .+�5.      �� -   5        ���#3f4e5c5.   (   o� 5/      $��190,0,100,0q�6   ��6(   Z� 50      � 51   
   $��1��6   $��2��6   .+�52      �� -   5        $��
tBlockTime��52        TblckTimeStyle#��[ 54      ��53      �� *	Timenow+ �� Source# [  54      �� 55      -   5          CollapseButtonStyle#��[ 55      .��57      �� .��58      �� $��Images/collapse.png��6   59      5:      �� 5;      -   5          ExitButtonStyle#��[ 5;      .��5=      �� .��5>      �� $��Images\exit.png��6   $��45��65   5?      5@      5A      �� 5B   
   	 �� Orientation$	 
Horizontal=�6   $��1��6.   $��1��6;   .+�5C      � .+�5D      �� -   5        $��
sourceTbox��5D        	BasicText#��[ 6,   

 � Tag$
 Введите IPv4...��5E      $��Bottom=�5F      |�. .��5H   +   5I      �� 5J      -	   5          SearchButtonStyle#��[ 5J      $��Bottom=�5L      .��5M      �� .��5N      �� $��Images\search.png��6    5O      5P      5R      �� 5U      -
   5        $��button��5U        MyIpButtonStyle#��[ 5V        	m_btnMyIp#���  5X      5Z      �� 5[   
   -   5        $��information_list��5[      $��2��6*   $��1��67   
���   �
���   �$
��Bold"�5^      $��16(�5_      $��
20,10,0,10q�5`      $��Bookman Old Style)�5a      $��Stretch=�5b      5d      5e      