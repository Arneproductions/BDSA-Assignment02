# Answers

This answer sheet is create by:
- Andreas Nicolaj Tietgen (anti)
- Daniel Lundin Lind (dll)
- Anton Friis (anlf)

## Question
*Consider the three different constructs in C#:*

- *Class*
- *Struct*
- *Record*
  
*Explain some of the key differences between the three and give examples of where you would use each of them.*

## Answer

### Class
A class is a reference type. Classes can inherit other classes(Only one class, but you can have a class hierarchy, unlike structs). Also by the nature of the reference type, it passes its instance as a reference to the underlying value in memory.

In object oriented programming classes are, in short, used to create and manage new objects and support inheritance.

### Struct
A struct is very similar to a class. However, there are several differences. For instance a struct cannot inherit from other classes. Structs are value-types that means that the struct is not passed by reference. So if a struct is passed as a parameter then a deep copy is created.

Because it is a value-type then it is best as a small data type. The advantage is that the struct-type does not have the same overhead as a class in terms of memory. Therefore structs are best used to represent a point from a coordinate system.

### Record
A record is a datatype that is especially good a being immutable. What is really special about Records is that they have a built in value equality comparer. It works by comparing every value rather than comparing a reference to the same object such as a class or a struct.

The record datatype have the option to create a copy of an existing record, but where specific chosen properties are changed.

Records have, just like classes, support for inheritance hierarchies. This is because records are related more to classes than structs.

A use case for a record could be for data structures where the data should not change and should be compared by the value. That could be point from a coordinate system or social security numbers.

