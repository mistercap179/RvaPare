   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5           WpfApp.Views.PredmetWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .VMclr-namespace:WpfApp.ViewModels     5      $	��382��5   4   .��5	      � $
��Left=�6   $	��321��6&   $��
0,0,0,39.6q�62     � ColumnDefinitions  5
   
   �� 5      $	��75* �6   �� 5      $	��32* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tabelaPredmet��5         AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�6   $��61,77,13.8,71.8q�6�   $��2��6�   ��6*   �� *
Predmeti+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Naziv+	   ElementStyle	 5      �� 5      
 �� 
TargetType"
 ��6    .�5      ��  �� Property � �� �� Value$ Center=�6D   6U   �� 5       � ��$ Center=�6B   5      5        5      $ Katedra��6%    .  66   �� *	Katedra+	 5      �� 5      "
 ��6    .�5      ��  � ��$ Center=�6D   6U   �� 5       � ��$ Center=�6B   5      5        5       $ Profesor��6%    .  67   �� *
Profesor+	 5!      �� 5"      "
 ��6    .�5#      ��  � ��$ Center=�6D   6U   �� 5$       � ��$ Center=�6B   5%      5'      4  .System.Windows.Controls.DataGridTemplateColumn  5(      $ Izmeni��6)      CellTemplate 5)      �� 5*      .R�5+      �� $��Izmeni��6%   ��5,      ��  �� Path$ DataContext.ModifyCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType"  ��5-   !   �� *SelectedItem+ �� ElementName$ tabelaPredmet��5.      5/      51        53      $ Obrisi��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69    54      �� 55      .R�56      �� $��Obrisi��6%   ��57      �� $ DataContext.DeleteCommand� �� *FindAncestor+"  ��58   !   �� *SelectedItem+$ tabelaPredmet��59      5:      5<      5>      �� 5?   
   -   5        $��Refresh��5?      $��Refresh��6C   $��219,289,10.8,0q�6U   $��31��6m   $	��Top=�6y    J� RenderTransformOrigin$ 0.503,-0.281&�6�   $��2��6�   ��6    �� *RefreshCommand+6�   �� 5@   
   -   5        $��
AddPredmet��5@      $��Dodaj predmet��6B   $��67,289,66.8,0q�6Z   $��31��6q   $	��Top=�6}   $ 0.503,-0.281&�6�   ��6#   �� *
AddCommand+6�   �� 5A   
   $��	Pretraga ��6   $
��Left=�6$   $��31,0,0,0q�6?   $	��Top=�6Q   $��40��6i   $��80��6u   �� 5B   
   $
��Left=�6\   $��26��6w   $��
168,27,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��96��6�   $��2��6�   $ 0.587,1.281&�6�   ��6   �� *Filter+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5C   
   $��Search��6   $��24��6D   $��74.2,8,-23.2,0q�6P   $	��Top=�6h   $��1��6�   $ 0.664,0.855&�6�   ��6"   �� *SearchCommand+6�   �� 5D   
   $��Cancel��6   $��24��6D   $��73.2,46,-22.2,0q�6P   $	��Top=�6i   $��1��6�   $ 0.018,0.358&�6�   ��6"   �� *CancelCommand+6�   �� 5E   
   $
��Left=�6g   $��26��6�   $��	32,25,0,0q�6�   $	��Top=�6�   $	��107��6�   ��6   �� *	ListBox+ �� SelectedItem 63   �� *SelectedItem+$ TwoWay=�6�   5F      5G      