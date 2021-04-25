# SourceFormat

SourceFormat describes a document structure. Documents can be described as trees. SourceFormat has
its own way to do so. The point of having a data structure describing any document structure is
providing an opportunity to create structures to any document the system would like to process.

The other field where a custom data structure can be used processing input data is cases where we
have input for a certain domain like addresses, but the address as field changes countries by
countries in its details. By describing UK, German, Hungarian and so on addresses and feed this
information to a form builder it is easy to manage these input tasks. This way we can provide data
type precision instead of manage details as text and having difficulties when these details needed
in further processing.

SourceFormat consists of:

- `SourceFormat`
- `DimensionStructureNode`

## SourceFormat

It contains the metadata about SourceFormat, like a unique identifier, `Name`, `Description` where
additional information can be provided, `url` which points to the source of the data.

## DimensionStructureNode

This one describes the structure portion of a document structure. It provides a tree where the nodes
can contains other, not structure related, information about a document structure. Such
as, `pattern` which describes where a new structural elem starts.

In order to manage easily that a document has structure, information belongs to a structural part
and display properties I had to split these. `DimensionStructureNode` is responsible for describing
structure.

It is a tree structure.

## Structure

```text
- SourceFormat
  -> RootDimensionStructureNode
    -> DimensionStructureNode (tree)
```

## Functionalities

### SourceFormat

### DimensionStructureNode
- Create a new node
- Insert a node
- Delete a node
- Update a node
- List nodes
- Find a node
- Get a node
- Get the tree
- Get the tree from a certain node