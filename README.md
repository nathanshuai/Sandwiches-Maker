# Sandwiches-Maker
Instructions

Create a simple console application that allows a user to "make a sandwich" within a set caloric range.

A list of available sandwich ingredients, along with their associated calories, is provided in the starter code.


Description of User Experience


A user should be prompted to enter minimum and maximum calories. The program will respond by creating and outputting a sandwich within the given calorie range. If the user enters a calorie range that makes it impossible to create a sandwich, the program should respond appropriately.

In addition to the calorie range restriction, the program should also take into account these requirements:

- Every sandwich must have exactly 2 slices of bread at the start and end of the sandwich
- You may have multiple copies of ingredients, but they may not be adjacent to each other.
	- Example: {"Bread", "Ham", "Ham", "Lettuce", "Bread"} is NOT okay.
	- Example: {"Bread", "Ham", "Lettuce", "Ham", "Bread"} IS okay.
- Every sandwich should use at least the minimum number of calories within the given range
- Every sandwich should use at most the maximum number of calories within the given range without going over.
