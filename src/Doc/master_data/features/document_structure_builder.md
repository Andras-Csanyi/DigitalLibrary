# Structure of a document

The purpose of the system to capture not only the content of a document but also its structure.
The point of capturing the structure is that it contains information too, and when one have
multiple documents in the system based on structure information possible to make connections
between content and structure.

In order to be able to store content in useful fashion we need to know the structure of the 
document we want to work with. When capturing the structure we use multiple and nested objects.

## Source

A Source describes from we get or request information. It can be and url or organization name,
like Gutenberg.org or any unique identifier.

## SourceFormat

SourceFormat object describes the document format belongs to a source. A Source can be an url,
for example a blog from where we query RSS feed, or content in defined format, for example
text files from [Gutenber](https://gutenberg.org).

## DimensionStructure and DimensionStructureNode

Understanding what is DimensionStructure one need to be aware of that in this system a 
document is considered as tree structure. In this tree the nodes may or may not contain
information. These nodes are the DimensionStructure objects. However, in the implementation
the tree is built by DimensionStructureNode objects. The reason is that we need to separate 
the information and functionality of a node. Information is the DimensionStructure, while
tree functionality is captured in DimensionStructureNode objects.

In case of text a DimensionStructure can be a paragraph, a sentence or a word. In case of HTML
document a DimensionStructure can be text wrapped in a HTML tag.

DimensionStructureNode describes the tree structure of DimensionStructures. They provide a wireframe
of the document and that objects, like DimensionStructure, can be added to nodes.