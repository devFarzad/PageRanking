# PageRanking
PageRank Algorithm, C#, WPF







Enter the Number of WebPages : 5
Enter the Adjacency Matrix with 1->PATH & 0->NO PATH Between two WebPages:

# Matrix

0 1 0 0 
0 0 0 1 
1 1 0 0 
0 0 1 0 




---------------------------------------------------------------
# Total Number of Nodes: 4	 Initial PageRank of All Nodes :0.25

# Initial PageRank Values , 0th Step 
 Page Rank of 1 is :	0.25
 Page Rank of 2 is :	0.25
 Page Rank of 3 is :	0.25
 Page Rank of 4 is :	0.25

# After 1th Step 
Page Rank of 1 is :	0.125
Page Rank of 2 is :	0.375
Page Rank of 3 is :	0.25
Page Rank of 4 is :	0.25

# After 2th Step 
Page Rank of 1 is :	0.125
Page Rank of 2 is :	0.25
Page Rank of 3 is :	0.25
Page Rank of 4 is :	0.375

# Final Page Rank : 
 Page Rank of 1 is :	0.25625
 Page Rank of 2 is :	0.3625
 Page Rank of 3 is :	0.3625
 Page Rank of 4 is :	0.46875
---------------------------------------------------------------
# Note
-Final Page Rank Includes Damping Factor of 0.85 which is usually set between 0 and 1.
-InternalNodeNumber represents the Node which you are currently calculating its PageRank.
-ExternalNodeNumber represents the Nodes Other than InternalNodeNumber.


For every InternalNodeNumber check if there is any Incoming Links from ExternalNodeNumber if No - Ignore and move to next ExternalNodeNumber,If Yes - Count all the OutgoingLinks for that ExternalNodeNumber.

Finally Calculate Pagerank :
PR(InternalNodeNumber) += PR(ExternalNodeNumber)/All OutgoingLinks for ExternalNodeNumber

So from the above values , We have Webpage A(1) is the most important Page , Webpage B(2) and C(3) have almost equal importance with B(2) slightly more importance ,Webpage D(4) has some importance and Webpage E(5) has least importance.This helps to Rank Webpages in the Search results.

Please Note: Actual google Page rank Algorithm for large network of webpages grows logarithmic and slightly different from the one above. This Page Rank algorithm is fully owned by google inc and I just illustrated with a help of a Java Program to implement this Algorithm .I hope you enjoyed this .Thanks Have Nice Day.

Update1: New Example has been Added and Images are Updated.
Update2: I have Considered Damping Factor in my Implementation which is set to 0.85.
Update3:while(u<=2) Changed to while(ITERATION_STEP<=2).

# Developers
 - [Farzad](https://github.com/theveloper90) 
