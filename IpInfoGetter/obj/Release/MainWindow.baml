   M S B A M L   `   `   `  ���� A  =who is, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:IpInfoGetterIpInfoGetter      IpInfoGetter.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:IpInfoGetter       � Title$   ��$	��270��$	��380�����#5F7D95$	��300��$	��490��$	��270��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources   IpInfoGetter.TimeNow   TimeNOW   Timenow  OnMouseDown1 �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime	 �� Value��%�   &	        &	        $  ���� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ button��.g�  $ 0��$	 	#FF8AC0F2��
 � Triggers
 :�  :� RoutedEvent$ UIElement.MouseDown�� :� 
SourceName$ button��.[��� -    ��Name$" OnMouseDown1_BeginStoryboard��#��[ :� $ UIElement.GotFocus��$ button��.[��� -   $# OnMouseDown1_BeginStoryboard1��#��[ .���  � ColumnDefinitions �� $	��25* ��� $
��180* ��� $	��10* � � RowDefinitions �� $	��25* ��� $	��25* ��� $
��140* �.+�� $��3��.+��� ���#8ac0f2�� -     BigButtonsStyle#��[ $��	4,0,3,230q�$��Bottom=�.���� .���� $��Images\more.png���� -   #��[ $��Bottom=�$��0,0,0,20q�$��3��.���� .���� $��Images\settings.png��� $��1��$��2��.+��� -   ���#3f4e5c� $��1��$��2��.+��� -    ��Name$ 
tBlockTime��$��23(�$	��134��$��Britannic Bold)�$
��Left=�
�������$
��Bold"� �� Padding$
 10,7q����� *	Timenow+ �� Source# [  �� -     CollapseButtonStyle#��[ $��	280,0,0,0q�.���� .���� $��Images/collapse.png���� -     ExitButtonStyle#��[ $��	370,0,0,0q�.���� .���� $��Images\exit.png��$��45����  �� Orientation$ 
Horizontal=�$��1��$��1��.+�� .+��� -	    ��Name$ 
sourceTbox��  	BasicText#��[ 
 � Tag$ Введите IPv4...��$��Bottom=�|�. �� -
     SearchButtonStyle#��[ $��Right=�$��Bottom=�$��0,0,0,4q�.���� .���� $��Images\search.png��$��30���� -    ��Name$ button��  EasyButtonStyle#��[ $��Bottom=�$��10,0,0,0q�$��5q�$��	мой IP��
��������� -    ��Name$ information_list��$��2��$��1��$	��140��$	��350��
���   �
���   �$
��Bold"�$��16(�$��
20,10,0,10q�$��Bookman Old Style)�$
��Left=�$	��370��