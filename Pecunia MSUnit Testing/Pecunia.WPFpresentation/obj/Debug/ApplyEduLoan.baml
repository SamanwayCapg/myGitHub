   M S B A M L   `   `   `  ����R  NPecunia.WPFpresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Pecunia.WPFpresentationPecunia.WPFpresentation  5   	   *    $Pecunia.WPFpresentation.ApplyEduLoan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Pecunia.WPFpresentation     5   	     � Title$  ApplyEduLoan��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� $��Apply Car Loan��6   $
��Left=�6)   $��
320,20,0,0q�6D   $	��Top=�6X   $	��160��6p   �� 5   
   $��Customer ID:��6   $
��Left=�6'   $��
106,52,0,0q�6B   $	��Top=�6V    J� RenderTransformOrigin$ 0.447,1.077&�6n   �� 5   
   -   5         ��Name$ customerIDTxtBox��5      $
��Left=�6-   $��23��6H   $��
271,55,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   �� 5   
   $��Amount (Rs.):��6   $
��Left=�6(   $��
106,92,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ amountAppliedTxtBox��5      $
��Left=�6/   $��23��6J   $��
271,96,0,0q�6V   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��120��6�   �� 5   
   $ ��Repayment Period (Months):��6   $
��Left=�65   $��106,138,0,0q�6P   $	��Top=�6e   �� 5   
   -   5        $ repaymentPeriodTxtBox��5      $
��Left=�61   $��23��6L   $��271,142,0,0q�6X   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   $��Course��6   $
��Left=�6!   $��106,187,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5         ��Name$ courseComboBox��5      $
��Left=�6+   $��271,187,0,0q�6F   $	��Top=�6[   $	��120��6s   .@�5      �� $��UNDERGRADUATE��6   $
��Left=�63   $	��118��6N   �� 5      $��MASTERS��6   $
��Left=�6-   $	��118��6H   �� 5      $	��PHD��6   $
��Left=�6)   $	��118��6D   �� 5      $��M_PHIL��6   $
��Left=�6,   $	��118��6G   �� 5      $��SERVICE��6   $
��Left=�6-   $	��118��6H   5      �� 5   
   $��Duration(years):��6   $
��Left=�6+   $��106,227,0,0q�6F   $	��Top=�6[   $ -0.684,0.769&�6s   �� 5   
   -   5        $ courseDurationTxtBox��5      $
��Left=�60   $��23��6K   $��271,231,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5!   
   $��Institute Name:��6   $
��Left=�6*   $��106,271,0,0q�6E   $	��Top=�6Z   $ 0.516,1.654&�6r   �� 5"   
   -   5        $ instituteNameTxtBox��5"      $
��Left=�60   $��23��6K   $��271,271,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5$   
   $��Student ID:��6   $
��Left=�6&   $��106,316,0,0q�6A   $	��Top=�6V   �� 5%   
   -   5        $ studentIDTxtBox��5%      $
��Left=�6+   $��23��6F   $��271,319,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5'   
   -   5         ��Name$ applyBtn��5'      $��Apply��6#   $
��Left=�63   $��316,376,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5)   
   -	   5        $ backBtn��5)      $
��Back��6"   $
��Left=�61   $��106,376,0,0q�6L   $	��Top=�6a   $��75��6y   $ 	0.04,0.85&�6�   6�   5+      5,      