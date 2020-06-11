# Document Structure Builder

A Document Structure describes a structure of a document, similarly as LaTeX does 
it with its sections at high level (below sections there are sentences and words if you like).

A Document Structure is a tree data structure where every node is a Document Structure.
A Document Structure, a node, can have a Dimension attached to it.

In the Digital Library system there are multiple inputs for example RSS feed, text file input,
any other file format input or different forms.

We need to be able to build these structures.

**Example - 1**:

A document structure is a reasonable - hopefully - good way to describe a form. In that case
when you have to manage multiple formats of addresses, because you manage data from EU, you
have to deal with all the different formats. If you have a tool for building up these data 
structures and generating the forms based on these. The only thing you have to do is providing
the proper directives/components and Blazor takes care of the remaining.

In the case above Document Structure describes the form and the data we would like to see.
The dimensions attached to the particular nodes describe that where the data will be stored
and coming from.

The look and feel of the form in the case above will be setup by the Form builder which uses
Document Structures as basic data structure.

**Example - 2**:

In case of HTML tags are defining, or give some guidance, what to expect.

**Example - 3**:

In case of special documents, like text files from gutenberg.org, the files has their own
structure. 

## Document Structure

Document Structure consists of DocumentStructure nodes and Dimensions attached to nodes.

Document Structure describes the node and its properties.

Dimension describes the data at the node and the place where it is stored.

## Mandatory fields

- Docuement structure name
- Document structure description

## Validations
- Document Structure name has to be unnique
- a Dimension cannot be added twice to a Document Structure
- a Document Structure cannot be added twice to a Dimension Structure
- Dimension has to be unique

All the above means that before saving server side validation must happen. 

## Features

### Create New Document Structure

#### Create a Brand New Document Structure

- Document structure name and description only
- Adding Existing Root Document Structure
- Adding a Newly Created Root Document Structure
- Adding Existing Document Structures to Root Document Structure
- Adding Newly Created Document Structures to Root Document Structure
- Adding Existing Dimensions to Document Structures
- Adding Newly Created Dimensions to Document Structures

#### Create a Document Structure copying and modifying an already existing one

- Delete Root Document Structure
- Delete Root Document Structure and add an Existing One
- Delete Root Document Structure and add a Newly created one
- Delete Any Document Structure from the tree
- Delete Any Document Structure from the tree and add an existing one
- Delete Any Document Structure from the tree and add a newly created one
- Delete Any Dimension fron any node
- Delete Any Dimension fron any node and add an existing one
- Delete Any Dimension fron any node and add a newly created one
- Replace Root Document Structure
- Replace Root Document Structure to an Existing One
- Replace Any Document Structure in the tree to an existing one
- Replace Any Dimension fron any node to an existing one

### Delete Document Structure
The Document Structure Builder user interface doesn't provide any option for deleting
Document Structures

### Edit Document Structure
- Delete Root Document Structure
- Delete Root Document Structure and add an Existing One
- Delete Root Document Structure and add a Newly created one
- Delete Any Document Structure from the tree
- Delete Any Document Structure from the tree and add an existing one
- Delete Any Document Structure from the tree and add a newly created one
- Delete Any Dimension fron any node
- Delete Any Dimension fron any node and add an existing one
- Delete Any Dimension fron any node and add a newly created one
- Replace Root Document Structure
- Replace Root Document Structure to an Existing One
- Replace Any Document Structure in the tree to an existing one
- Replace Any Dimension fron any node to an existing one