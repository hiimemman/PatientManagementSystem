   M S B A M L   `   `   `  ���� R  NPatientManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PatientManagementSystemPatientManagementSystem  *    $PatientManagementSystem.Radiographic   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:PatientManagementSystem     $
��1000��.��� .+�� -     �Name$  gridSideBar��$y�Visible=� � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0�����	#FF172554$��	0,0,100,0q�.+��� $
��Left=���Z� ��Z� .����  �� Orientation$ 
Horizontal=�.+��� $$��/assets/images/ezaret-logo.png��$��38��$��40��$��1,0,10,0q��� $��ADMIN��$��Center=�$��Arial)�$��11(����	#FFF4F4F5$��53���� $��0,10,0,0q�$
��Left=���Z� ��Z� .���� $ 
Horizontal=�.+��� $6��0/assets/images/baseline_dashboard_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��	Dashboard��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $<��6/assets/images/baseline_personal_injury_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��Patients��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $3��-/assets/images/baseline_people_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��Users��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$��99����Z� ��Z� .���� $ 
Horizontal=�.+��� $8��2/assets/images/baseline_description_white_24dp.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Lab Test��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$��99����Z� ��Z� .���� $ 
Horizontal=�.+��� $$��/assets/images/pill-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��	Drug Test��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$��99����Z� ��Z� .���� $ 
Horizontal=�.+��� $)��#/assets/images/test-tube-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Herma��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q����	#FF1E40AF$
��Left=�$	��100��.���� $ 
Horizontal=�.+��� $-��'/assets/images/radiology-box-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Radio��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $-��'/assets/images/emoticon-poop-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��	Fecalysis��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -	   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $;��5/assets/images/baseline_account_circle_white_24dp.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Account��$��Center=�$��Arial)�$��11(����	#FFF4F4F5� -
   $  gridDataTable��$��2��$��	100,0,0,0q����	#FF1E293B$y�Visible=�.+��� $��Radiographic��$��Center=�$	��Top=����	#FFF4F4F5$��30(�$	��225��$
��Bold"��� $
��Auto=�$
��Auto=�.��&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��10,120,0,60q����� *users+   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=���  � ��$ 25����  � ��$ Black"���  �@ SeparatorBrush
 �������  � �� �� .R��� $
��20,0q����� �� -   $��Add new��$
��Left=�$��	10,80,0,0q�$	��Top=����	#FF052E16���	#FF86EFAC$	��101���� -   $��Refresh��$
��Left=�$��
116,80,0,0q�$	��Top=����	#FF052E16
�������$	��101���� -   $��searchTextBox��$��Right=�$��
0,81,104,0q� �� TextWrapping$
 Wrap=�$��Search for item here....��$	��Top=�$	��300���� -   $��Search��$��Right=�$	��Top=�$��74��$��	0,80,10,0q����	#FF052E16
��������� -   	 ��Name$	 gridAddData��$��0,0,0,0q�$y�	Collapsed=�.��� 
������ $	��800��
 J� RenderTransformOrigin$
 0.48,0&�$
��1000��.+��� $��ADD RADIOGRAPHIC��$��Center=�$��50(����	#FFF3E9E9$��
0,10,0,912q�$��Century Gothic)�$
��Bold"��� $��
Patient Id��$��30(�$
��Left=����	#FFF3E9E9$��20,123,0,823q�$	��155���� -    ��Name$ txtPatientId��$
��Left=�$��
20,182,0,0q�$
 Wrap=�$	��Top=�$	��747��$��30(����	#FF075985�� $��
Impression��$��30(�$
��Left=����	#FFF3E9E9$��20,232,0,709q�$	��155���� -   $ txtImpression��$
��Left=�$��
20,291,0,0q�$
 Wrap=�$	��Top=�$	��747��$��30(����	#FF075985�� $��Interpretation��$��30(�$
��Left=����	#FFF3E9E9$��20,346,0,598q�$	��213���� -   $ txtInterpretation��$
��Left=�$��
20,407,0,0q�$
 Wrap=�$	��Top=�$	��747��$��30(����	#FF075985�� $��Reference No��$��30(�$
��Left=����	#FFF3E9E9$��20,450,0,493q�$	��213���� -   $ txtReferenceNo��$
��Left=�$��
20,507,0,0q�$
 Wrap=�$	��Top=�$	��747��$��30(����	#FF075985�� $��Type of exam��$��30(�$
��Left=����	#FFF3E9E9$��20,550,0,398q�$	��213���� -   $ txtTypeOfExam��$
��Left=�$��
20,607,0,0q�$
 Wrap=�$	��Top=�$	��747��$��30(����	#FF075985�� -   $
��SAVE��$
��Left=�$��
20,723,0,0q�$	��Top=����	#FF052E16
�������$	��478��$��58���� -   $��CANCEL��$
��Left=�$��508,723,0,0q�$	��Top=�
�������
�������$	��259��$��57��