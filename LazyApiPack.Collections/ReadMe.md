# About this pack
This package provides extensions for collections and special collection types.

# Special Collections
## BoolList
This class provides a list of named bools to be evaluated as a boolean.

**Example:**
```csharp
var b1 = new BoolList(BoolListMode.AllTrue);
b1["View Loaded"] = false;
b1["Model present"] = true;

Console.WriteLine("Value: " + b1);
Console.WriteLine("Reason:\n" + b1.ToString());

```
**Output:** 

Value: false
Reason:
Value: false
Mode: AllTrue
Values:
View Loaded: false
Model Present: true

### Modes
AllTrue: Result is only true, if **all** items in the list are True => Logical And
AtLeastOne: Result is true, if the list contains **at least** one item that is true => Logical Or
ExactlyOne: Result is only true, if **exactly one** item in the list is true => Logical Xor. 

# Extensions
## Array Extensions
### Append
Adds an element to an array and resizes the array.

### Insert
Inserts an element to an array (resizes the array if the index is Array.Length)

### RemoveRange
Removes a range of elements and resizes the array.

## Dictionary Extensions
### Upsert
Adds a key to a dictionary if it does not exist or updates its value.