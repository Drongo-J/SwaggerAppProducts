   M S B A M L   `   `   `  ����K  GE-CommerceClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:E_CommerceClientE_CommerceClient  5   	   !    E_CommerceClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:E_CommerceClient     5   	   -   5          �Name$  w��5   	    � Icon$ \Assets\client.png��5	   	    � Title$ Client��5
   	   $	��450��6   $	��800��6%    � 	Resources 5         MyFontFamily �� 
TargetType  TBSTYLE �� Property �� Value��%?  &	        &	 8     7   *�5   
   $ /FontFamilies/#Righteous Regular)�6L   �� 5   
   " ��6   .�5      ��  � ��8   6S   �� 5       � ��$ 19)�6+   68   �� 5       �@��Padding$ 7q�6(   64   �� 5       � ��$ Black"�6+   6;   �� 5       � ��
 �� �6A   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��6* �6   6*   .+�5   
   � $��0��6   .+�5      �� .+�5      �� $��Products (Click to buy)��6   $��30(�5       �� Padding$	 0,8q�5       #��[  5!      $
��Bold"�5"      
���� �	 �� TextAlignment$	 Center=�5$      5%      �� 5'      
���� �$��2q�5(      5)      5*      5+      � 5-   
   $��1��6   .+�5.      �� -   5        $��2q�50      ��5.      �� *
Products+��51      �� 52      .R�53      �� 
���  ��$��2q�54   !   ��55   !   �� 
 �� ElementName$
 w�� �� Path$ ActualWidth�._�56      � .+�57   "   �� $��0q�6)   ._�58   &   �� .+�59   *   �� $
	 Left=�64   $��30��5:   4   #��[ 5;   4   ��5<   4   �� *ProductName+5=   +   �� 5>   *   $
	 Left=�64   $��30��5?   4   #��[ 5A   4   ��5@   4   �� *	UnitPrice+5B   +   �� 5C   *   $
	 Left=�64   $��30��5D   4   #��[ 5E   4   ��5F   4   �� *UnitsInStock+5G   +   �� 5H   *   $
	 Left=�64   $��30��5I   4   #��[ 5J   4   ��5K   4   �� *
Category+5L   +   5M   '   5N   #   5O      5P      5Q      5S      5T      5U      5V      