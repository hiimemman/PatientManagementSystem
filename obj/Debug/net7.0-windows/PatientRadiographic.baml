   M S B A M L   `   `   `  ����R  NPatientManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PatientManagementSystemPatientManagementSystem  5      1    +PatientManagementSystem.PatientRadiographic   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PatientManagementSystem     5      -   5          >�Name$  PatientRadiographicUser��5   7   .��5
      � .+�5   
   � -   5         �Name$ gridSideBar��5      $y�Visible=�6$    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   ���	#FF172554$��	0,0,100,0q�6@   .+�5      �� $
��Left=�6F   ��6   Z� ��6/   Z� .��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $$��/assets/images/ezaret-logo.png��6    $��38��6H   $��40��6S   $��1,0,10,0q�6_   �� 5      $
��USER��6$   $��Center=�60   $��Arial)�6K   $��11(�6^   ���	#FFF4F4F5$��53��6�   5      5      �� 5      -   5        $��0,0,0,0q�5      $
��Left=�6W   $��99��6r   ��6*   Z� ��6@   Z� .��5      �� $ 
Horizontal=�6!   .+�5       �� $8��2/assets/images/baseline_description_white_24dp.png��6    $��20��6\   $��20��6g   $��1,0,10,0q�6s   $
��Left=�6�   �� 5!      $��Lab Test��6$   $��Center=�64   $��Arial)�6O   $��11(�6b   ���	#FFF4F4F56p   5"      5$      �� 5&      -   5        $��0,0,0,0q�5&      $
��Left=�6W   $��99��6r   ��6*   Z� ��6@   Z� .��5(      �� $ 
Horizontal=�6!   .+�5)      �� $$��/assets/images/pill-custom.png��6    $��20��6H   $��20��6S   $��1,0,10,0q�6_   $
��Left=�6q   �� 5*      $��	Drug Test��6$   $��Center=�65   $��Arial)�6P   $��11(�6c   ���	#FFF4F4F56q   5+      5-      �� 5/      -   5        $��0,0,0,0q�5/      $
��Left=�6W   $��99��6r   ��6*   Z� ��6@   Z� .��51      �� $ 
Horizontal=�6!   .+�52      �� $)��#/assets/images/test-tube-custom.png��6    $��20��6M   $��20��6X   $��1,0,10,0q�6d   $
��Left=�6v   �� 53      $��Herma��6$   $��Center=�61   $��Arial)�6L   $��11(�6_   ���	#FFF4F4F56m   54      56      �� 58      -   5        $��0,0,0,0q�58      ���	#FF1E40AF$
��Left=�6A   $	��100��6\   .��5:      �� $ 
Horizontal=�6!   .+�5;      �� $-��'/assets/images/radiology-box-custom.png��6    $��20��6Q   $��20��6\   $��1,0,10,0q�6h   $
��Left=�6z   �� 5<      $��Radio��6$   $��Center=�61   $��Arial)�6L   $��11(�6_   ���	#FFF4F4F56m   5=      5?      �� 5A      -   5        $��0,0,0,0q�5A      $
��Left=�6W   $	��100��6r   ��6*   Z� ��6@   Z� .��5C      �� $ 
Horizontal=�6!   .+�5D      �� $-��'/assets/images/emoticon-poop-custom.png��6    $��20��6Q   $��20��6\   $��1,0,10,0q�6h   $
��Left=�6z   �� 5E      $��	Fecalysis��6$   $��Center=�65   $��Arial)�6P   $��11(�6c   ���	#FFF4F4F56q   5F      5H      �� 5K      -   5        $��0,0,0,0q�5K      $
��Left=�6W   $	��100��6r   ��6*   Z� ��6@   Z� .��5M      �� $ 
Horizontal=�6!   .+�5N      �� $.��(/assets/images/logout-variant-custom.png��6    $��20��6R   $��20��6]   $��1,0,10,0q�6i   $
��Left=�6{   �� 5O      $��Logout��6$   $��Center=�62   $��Arial)�6M   $��11(�6`   ���	#FFF4F4F56n   5P      5R      5T      5U      � 5W   
   -	   5        $ gridDataTable��5W   N   $��2��6   $��	100,0,0,0q�6$   ���	#FF1E293B$y�Visible=�6e   .+�5X      �� $��Radiographic��6   $��Center=�6+   $	��Top=�6H   ���	#FFF4F4F5$��30(�6w   $	��202��6�   $
��Bold"�6�   �� 5Z      $��PatientID :��6   $
��Left=�6*   $��	11,61,0,0q�6E   $	��Top=�6X   ���	#FFF4F4F5$��25(�6�   $��DemiBold"�6�   �� 5\      $
��Left=�6:   $��
134,61,0,0q�6U   $	��Top=�6i   ���	#FFF4F4F5$��25(�6�   ��6   ��  �� Path$ 	PatientId�6�   �� 5^      $��Reference :��6   $
��Left=�6*   $��
10,109,0,0q�6E   $	��Top=�6Y   ���	#FFF4F4F5$��25(�6�   $��DemiBold"�6�   �� 5_      $
��Left=�6;   $��146,109,0,0q�6V   $	��Top=�6k   ���	#FFF4F4F5$��25(�6�   ��6   �� $ ReferenceNo�6�   �� 5c      $��Impression :��6   $
��Left=�6+   $��
10,173,0,0q�6F   $	��Top=�6Z   ���	#FFF4F4F5$��25(�6�   $��DemiBold"�6�   �� 5f      $
��Left=�6<   $��153,172,0,0q�6W   $	��Top=�6l   ���	#FFF4F4F5$��25(�6�   ��6   �� $ 
Impression�6�   �� 5h      $��Date:��6   $��Right=�6$   $��
0,61,262,0q�6@   $	��Top=�6T   ���	#FFF4F4F5$��25(�6�   $��DemiBold"�6�   �� 5i      $��Right=�6;   $��585,61,0,10q�6W   $	��Top=�6l   ���	#FFF4F4F5$��25(�6�   ��6   �� $ DateCreated�6�   �� 5k      $��Interpretation :��6   $
��Left=�6/   $��239,172,0,0q�6J   $	��Top=�6_   ���	#FFF4F4F5$��25(�6�   $��DemiBold"�6�   �� 5l      $
��Left=�6?   $��414,171,0,0q�6Z   $	��Top=�6o   ���	#FFF4F4F5$��25(�6�   ��6   �� $ Interpretation�6�   5n      5q      5r      