   M S B A M L   `   `   `  ����R  NPecunia.WPFpresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Pecunia.WPFpresentationPecunia.WPFpresentation  5   	   ,    &Pecunia.WPFpresentation.LoanMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Pecunia.WPFpresentation     5   	     � Title$  LoanMainWindow��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ ApplyCarLoan��5
      $��Apply Car Loan��6(   $
��Left=�6A   $	��Top=�6\   $	��136��6t   $��
111,44,0,0q�6�   6�   �� 5   
   -   5        $ ApplyHomeLoan��5      $��Apply Home Loan��6(   $
��Left=�6B   $��
111,93,0,0q�6]   $	��Top=�6q   $	��136��6�    J� RenderTransformOrigin$ -0.441,0.372&�6�   6�   �� 5   
   -   5        $ ApplyEduLoan��5      $��Apply Edu Loan��6(   $
��Left=�6A   $��111,143,0,0q�6\   $	��Top=�6q   $	��136��6�   6�   �� 5   
   -   5        $ ApproveCarLoan��5      $��Approve Car Loan��6*   $
��Left=�6E   $��
532,44,0,0q�6`   $	��Top=�6t   $	��126��6�   6�   �� 5   
   -   5        $ ApproveHomeLoan��5      $��Approve Home Loan��6*   $
��Left=�6F   $��
532,93,0,0q�6a   $	��Top=�6u   $	��126��6�   $ -0.182,1.362&�6�   6�   �� 5   
   -   5        $ ApproveEduLoan��5      $��Approve Edu Loan��6*   $
��Left=�6E   $��532,143,0,0q�6`   $	��Top=�6u   $	��126��6�   6�   �� 5   
   $��Search Loan��6   $
��Left=�6&   $��107,211,0,0q�6A   $	��Top=�6V   �� 5   
   -   5         ��Name$ SearchLoanComboBox��5      $
��Left=�6/   $��186,211,0,0q�6J   $	��Top=�6_   $	��120��6w   .@�5      �� $��By Customer ID��6   $
��Left=�64   $	��118��6O   �� 5      $��
By Loan ID��6   $
��Left=�64   $	��118��6O   5      �� 5   
   -   5        $ selectLoanTypeComboBox��5      $
��Left=�64   $��311,211,0,0q�6O   $	��Top=�6d   $	��120��6|   .@�5      �� $��	Home Loan��6   $
��Left=�6/   $	��118��6J   �� 5      $��Car Loan��6   $
��Left=�6/   $	��118��6J   �� 5      $��Edu Loan��6   $
��Left=�6/   $	��118��6J   5      �� 5    
   -	   5         ��Name$ 	IDtextBox��5       $
��Left=�6%   $��23��6@   $��436,212,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   $ 0.375,0.565&�6�   �� 5!   
   -
   5        $ SearchLoanBtn��5!      $��SEARCH��6(   $
��Left=�69   $��561,211,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5#   
   -   5        $ BackBtn��5#      $
��Back��6"   $
��Left=�61   $��294,358,0,0q�6L   $	��Top=�6a   $��75��6y   6�   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ dataGrid��5%      $
��Left=�6%   $��94��6@   $��
10,259,0,0q�6L   $	��Top=�6`   $	��772��6x   5'      5(      