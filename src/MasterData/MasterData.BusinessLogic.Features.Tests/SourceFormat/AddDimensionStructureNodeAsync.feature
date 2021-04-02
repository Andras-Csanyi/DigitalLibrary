Feature: SourceFormat Business Logic - Add DimensionStructureNode

As a Data Owner and Data Curator
I have to be able to manage data structures in the system including SourceFormat
Which includes managing the DimensionStructureNode trees of SourceFormats

    Scenario: Adds DimensionStructureNode to the root DimensionStructureNode as child

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value               |
          | IsActive  | 1                   |
          | ResultKey | ds-node-to-be-added |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | sf-2-root-node      |
          | ToBeAddedDimensionStructureNodeKey | ds-node-to-be-added |
          | OperationResultKey                 | add-dsn-sf-result   |

        Then operation result is
          | Field         | Value             |
          | Key           | add-dsn-sf-result |
          | ExpectedValue | SUCCESS           |

        And DimensionStructureNode is requested
          | Field     | Value               |
          | Key       | ds-node-to-be-added |
          | ResultKey | ds-node-requested   |

        And DimensionStructure's property is not empty
          | Field        | Value             |
          | Key          | ds-node-requested |
          | PropertyName | SourceFormatId    |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value             |
          | Key                                    | ds-node-requested |
          | PropertyName                           | SourceFormatId    |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result       |
          | ReferencedSourceFormatPropertyName     | Id                |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value               |
          | Key                | sf-2-with-tree      |
          | SearchForObjectKey | ds-node-to-be-added |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value               |
          | TreeKey            | sf-2-with-tree      |
          | SearchForObjectKey | ds-node-to-be-added |
          | ParentKey          | sf-2-root-node      |

        And DimensionStructureNode parent in the database is
          | Field     | Value               |
          | ChildKey  | ds-node-to-be-added |
          | ParentKey | sf-2-root-node      |

    Scenario: Adds a second DimensionStructureNode to the root DimensionStructureNode as child

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN
    #          |-> DSN

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value                |
          | IsActive  | 1                    |
          | ResultKey | ds-node1-to-be-added |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                |
          | SourceFormatKey                    | sf-2-result          |
          | ParentDimensionStructureNodeKey    | sf-2-root-node       |
          | ToBeAddedDimensionStructureNodeKey | ds-node1-to-be-added |
          | OperationResultKey                 | add-dsn1-sf-result   |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value                |
          | IsActive  | 1                    |
          | ResultKey | ds-node2-to-be-added |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                |
          | SourceFormatKey                    | sf-2-result          |
          | ParentDimensionStructureNodeKey    | sf-2-root-node       |
          | ToBeAddedDimensionStructureNodeKey | ds-node2-to-be-added |
          | OperationResultKey                 | add-dsn2-sf-result   |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | ds-node1-to-be-added |
          | ResultKey | ds-node1-requested   |

        And DimensionStructure's property is not empty
          | Field        | Value              |
          | Key          | ds-node1-requested |
          | PropertyName | SourceFormatId     |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value              |
          | Key                                    | ds-node1-requested |
          | PropertyName                           | SourceFormatId     |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result        |
          | ReferencedSourceFormatPropertyName     | Id                 |

        And DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | ds-node2-to-be-added |
          | ResultKey | ds-node2-requested   |

        And DimensionStructure's property is not empty
          | Field        | Value              |
          | Key          | ds-node2-requested |
          | PropertyName | SourceFormatId     |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value              |
          | Key                                    | ds-node2-requested |
          | PropertyName                           | SourceFormatId     |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result        |
          | ReferencedSourceFormatPropertyName     | Id                 |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value                |
          | Key                | sf-2-with-tree       |
          | SearchForObjectKey | ds-node1-to-be-added |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value                |
          | TreeKey            | sf-2-with-tree       |
          | SearchForObjectKey | ds-node1-to-be-added |
          | ParentKey          | sf-2-root-node       |

        And DimensionStructureNode parent in the database is
          | Field     | Value                |
          | ChildKey  | ds-node1-to-be-added |
          | ParentKey | sf-2-root-node       |

        And DimensionStructureNode is in the tree
          | Field              | Value                |
          | Key                | sf-2-with-tree       |
          | SearchForObjectKey | ds-node2-to-be-added |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value                |
          | TreeKey            | sf-2-with-tree       |
          | SearchForObjectKey | ds-node2-to-be-added |
          | ParentKey          | sf-2-root-node       |

        And DimensionStructureNode parent in the database is
          | Field     | Value                |
          | ChildKey  | ds-node2-to-be-added |
          | ParentKey | sf-2-root-node       |

    Scenario: Adds a third DimensionStructureNode to the root DimensionStructureNode as child

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN
    #          |-> DSN
    #          |-> DSN

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value                |
          | IsActive  | 1                    |
          | ResultKey | ds-node1-to-be-added |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                |
          | SourceFormatKey                    | sf-2-result          |
          | ParentDimensionStructureNodeKey    | sf-2-root-node       |
          | ToBeAddedDimensionStructureNodeKey | ds-node1-to-be-added |
          | OperationResultKey                 | add-dsn1-sf-result   |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value                |
          | IsActive  | 1                    |
          | ResultKey | ds-node2-to-be-added |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                |
          | SourceFormatKey                    | sf-2-result          |
          | ParentDimensionStructureNodeKey    | sf-2-root-node       |
          | ToBeAddedDimensionStructureNodeKey | ds-node2-to-be-added |
          | OperationResultKey                 | add-dsn2-sf-result   |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value                |
          | IsActive  | 1                    |
          | ResultKey | ds-node3-to-be-added |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                |
          | SourceFormatKey                    | sf-2-result          |
          | ParentDimensionStructureNodeKey    | sf-2-root-node       |
          | ToBeAddedDimensionStructureNodeKey | ds-node3-to-be-added |
          | OperationResultKey                 | add-dsn3-sf-result   |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | ds-node1-to-be-added |
          | ResultKey | ds-node1-requested   |

        And DimensionStructure's property is not empty
          | Field        | Value              |
          | Key          | ds-node1-requested |
          | PropertyName | SourceFormatId     |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value              |
          | Key                                    | ds-node1-requested |
          | PropertyName                           | SourceFormatId     |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result        |
          | ReferencedSourceFormatPropertyName     | Id                 |

        And DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | ds-node2-to-be-added |
          | ResultKey | ds-node2-requested   |

        And DimensionStructure's property is not empty
          | Field        | Value              |
          | Key          | ds-node2-requested |
          | PropertyName | SourceFormatId     |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value              |
          | Key                                    | ds-node2-requested |
          | PropertyName                           | SourceFormatId     |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result        |
          | ReferencedSourceFormatPropertyName     | Id                 |

        And DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | ds-node3-to-be-added |
          | ResultKey | ds-node3-requested   |

        And DimensionStructure's property is not empty
          | Field        | Value              |
          | Key          | ds-node3-requested |
          | PropertyName | SourceFormatId     |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value              |
          | Key                                    | ds-node3-requested |
          | PropertyName                           | SourceFormatId     |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result        |
          | ReferencedSourceFormatPropertyName     | Id                 |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value                |
          | Key                | sf-2-with-tree       |
          | SearchForObjectKey | ds-node1-to-be-added |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value                |
          | TreeKey            | sf-2-with-tree       |
          | SearchForObjectKey | ds-node1-to-be-added |
          | ParentKey          | sf-2-root-node       |

        And DimensionStructureNode parent in the database is
          | Field     | Value                |
          | ChildKey  | ds-node1-to-be-added |
          | ParentKey | sf-2-root-node       |

        And DimensionStructureNode is in the tree
          | Field              | Value                |
          | Key                | sf-2-with-tree       |
          | SearchForObjectKey | ds-node2-to-be-added |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value                |
          | TreeKey            | sf-2-with-tree       |
          | SearchForObjectKey | ds-node2-to-be-added |
          | ParentKey          | sf-2-root-node       |

        And DimensionStructureNode parent in the database is
          | Field     | Value                |
          | ChildKey  | ds-node2-to-be-added |
          | ParentKey | sf-2-root-node       |

        And DimensionStructureNode is in the tree
          | Field              | Value                |
          | Key                | sf-2-with-tree       |
          | SearchForObjectKey | ds-node3-to-be-added |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value                |
          | TreeKey            | sf-2-with-tree       |
          | SearchForObjectKey | ds-node3-to-be-added |
          | ParentKey          | sf-2-root-node       |

        And DimensionStructureNode parent in the database is
          | Field     | Value                |
          | ChildKey  | ds-node3-to-be-added |
          | ParentKey | sf-2-root-node       |

    Scenario: Adds a DimensionStructureNode to the level 1 named 1

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

    Scenario: Adds a second DimensionStructureNode to the level 1 named 2

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #              |-> DSN (dsn-root-1-2)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

    Scenario: Adds a third DimensionStructureNode to the level 1 named 3

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

    Scenario: Adds a DimensionStructureNode to the level 2 named 1

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

    Scenario: Adds a second DimensionStructureNode to the level 2 named 2

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                |-> DSN (dsn-root-1-1-2)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

    Scenario: Adds a third DimensionStructureNode to the level 2 named 3

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                |-> DSN (dsn-root-1-1-2)
    #                |-> DSN (dsn-root-1-1-3)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-3 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-3-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-3           |
          | ResultKey | dsn-root-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-3-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-3-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-3 |
          | ParentKey | dsn-root-1-1   |

    Scenario: Adds a DimensionStructureNode to the level 3 named 1

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-1)
    #                |-> DSN (dsn-root-1-1-2)
    #                |-> DSN (dsn-root-1-1-3)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-1 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-1-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-3           |
          | ResultKey | dsn-root-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-3-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-3-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-1           |
          | ResultKey | dsn-root-1-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-3 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-1 |
          | ParentKey | dsn-root-1-1-1   |

    Scenario: Adds a second DimensionStructureNode to the level 3 named 2

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-2)
    #                |-> DSN (dsn-root-1-1-2)
    #                |-> DSN (dsn-root-1-1-3)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-2 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-1-2-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-3           |
          | ResultKey | dsn-root-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-3-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-3-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-1           |
          | ResultKey | dsn-root-1-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-2           |
          | ResultKey | dsn-root-1-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-2-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-2-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-3 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-1 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-2 |
          | ParentKey | dsn-root-1-1-1   |

    Scenario: Adds a third DimensionStructureNode to the level 3 named 3

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-2)
    #                  |-> DSN (dsn-root-1-1-1-3)
    #                |-> DSN (dsn-root-1-1-2)
    #                |-> DSN (dsn-root-1-1-3)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-3 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-1-3-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-3           |
          | ResultKey | dsn-root-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-3-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-3-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-1           |
          | ResultKey | dsn-root-1-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-2           |
          | ResultKey | dsn-root-1-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-2-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-2-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-3           |
          | ResultKey | dsn-root-1-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-3-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-3-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-3 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-1 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-2 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-3 |
          | ParentKey | dsn-root-1-1-1   |

    Scenario: Adds a fourth DimensionStructureNode to the level 3 named 2-1

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-2)
    #                  |-> DSN (dsn-root-1-1-1-3)
    #                |-> DSN (dsn-root-1-1-2)
    #                  |-> DSN (dsn-root-1-1-2-1)
    #                |-> DSN (dsn-root-1-1-3)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-2-1 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-2          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2-1        |
          | OperationResultKey                 | dsn-root-1-1-2-1-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-3           |
          | ResultKey | dsn-root-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-3-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-3-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-1           |
          | ResultKey | dsn-root-1-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-2           |
          | ResultKey | dsn-root-1-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-2-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-2-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-3           |
          | ResultKey | dsn-root-1-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-3-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-3-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-2-1           |
          | ResultKey | dsn-root-1-1-2-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-2-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-2-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-3 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-1 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-2 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-3 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-1 |
          | ParentKey          | dsn-root-1-1-2   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-2-1 |
          | ParentKey | dsn-root-1-1-2   |

    Scenario: Adds a fifth DimensionStructureNode to the level 3 named 2-2

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-2)
    #                  |-> DSN (dsn-root-1-1-1-3)
    #                |-> DSN (dsn-root-1-1-2)
    #                  |-> DSN (dsn-root-1-1-2-1)
    #                  |-> DSN (dsn-root-1-1-2-2)
    #                |-> DSN (dsn-root-1-1-3)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-2-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-2          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2-1        |
          | OperationResultKey                 | dsn-root-1-1-2-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-2-2 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-2          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2-2        |
          | OperationResultKey                 | dsn-root-1-1-2-2-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-3           |
          | ResultKey | dsn-root-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-3-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-3-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-1           |
          | ResultKey | dsn-root-1-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-2           |
          | ResultKey | dsn-root-1-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-2-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-2-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-3           |
          | ResultKey | dsn-root-1-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-3-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-3-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-2-1           |
          | ResultKey | dsn-root-1-1-2-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-2-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-2-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-2-2           |
          | ResultKey | dsn-root-1-1-2-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-2-2-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-2-2-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-3 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-1 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-2 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-3 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-1 |
          | ParentKey          | dsn-root-1-1-2   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-2-1 |
          | ParentKey | dsn-root-1-1-2   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-2 |
          | ParentKey          | dsn-root-1-1-2   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-2-2 |
          | ParentKey | dsn-root-1-1-2   |

    Scenario: Adds a sixth DimensionStructureNode to the level 3 named 2-3

    #      Test case:
    #      SF
    #      |-> RootDimensionStructureNode
    #          |-> DSN (dsn-root-1)
    #              |-> DSN (dsn-root-1-1)
    #                |-> DSN (dsn-root-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-1)
    #                  |-> DSN (dsn-root-1-1-1-2)
    #                  |-> DSN (dsn-root-1-1-1-3)
    #                |-> DSN (dsn-root-1-1-2)
    #                  |-> DSN (dsn-root-1-1-2-1)
    #                  |-> DSN (dsn-root-1-1-2-2)
    #                  |-> DSN (dsn-root-1-1-2-3)
    #                |-> DSN (dsn-root-1-1-3)
    #              |-> DSN (dsn-root-1-2)
    #              |-> DSN (dsn-root-1-3)

        Given there is a saved SourceFormat domain object
          | Field     | Value       |
          | Name      | sf-2        |
          | Desc      | sf-2        |
          | IsActive  | 1           |
          | ResultKey | sf-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | sf-2-root-node |

        And DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey           | sf-2-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value      |
          | IsActive  | 1          |
          | ResultKey | dsn-root-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value             |
          | SourceFormatKey                    | sf-2-result       |
          | ParentDimensionStructureNodeKey    | sf-2-root-node    |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1        |
          | OperationResultKey                 | dsn-root-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1        |
          | OperationResultKey                 | dsn-root-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-2        |
          | OperationResultKey                 | dsn-root-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value        |
          | IsActive  | 1            |
          | ResultKey | dsn-root-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | dsn-root-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-3        |
          | OperationResultKey                 | dsn-root-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value          |
          | IsActive  | 1              |
          | ResultKey | dsn-root-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                 |
          | SourceFormatKey                    | sf-2-result           |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-1        |
          | OperationResultKey                 | dsn-root-1-1-1-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-2        |
          | OperationResultKey                 | dsn-root-1-1-1-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-1          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-1-3        |
          | OperationResultKey                 | dsn-root-1-1-1-3-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-2-1 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-2          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2-1        |
          | OperationResultKey                 | dsn-root-1-1-2-1-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-2-2 |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-2          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2-2        |
          | OperationResultKey                 | dsn-root-1-1-2-2-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value            |
          | IsActive  | 1                |
          | ResultKey | dsn-root-1-1-2-3 |

        When DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-2          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2-3        |
          | OperationResultKey                 | dsn-root-1-1-2-3-result |

        Then DimensionStructureNode is requested
          | Field     | Value                |
          | Key       | dsn-root-1           |
          | ResultKey | dsn-root-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                |
          | Key          | dsn-root-1-requested |
          | PropertyName | SourceFormatId       |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                |
          | Key                                    | dsn-root-1-requested |
          | PropertyName                           | SourceFormatId       |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result          |
          | ReferencedSourceFormatPropertyName     | Id                   |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-1           |
          | ResultKey | dsn-root-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-1-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-1-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-2           |
          | ResultKey | dsn-root-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-2-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-2-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                  |
          | Key       | dsn-root-1-3           |
          | ResultKey | dsn-root-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                  |
          | Key          | dsn-root-1-3-requested |
          | PropertyName | SourceFormatId         |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                  |
          | Key                                    | dsn-root-1-3-requested |
          | PropertyName                           | SourceFormatId         |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result            |
          | ReferencedSourceFormatPropertyName     | Id                     |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-1           |
          | ResultKey | dsn-root-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-1-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-1-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-2           |
          | ResultKey | dsn-root-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-2-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-2-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                    |
          | Key       | dsn-root-1-1-3           |
          | ResultKey | dsn-root-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                    |
          | Key          | dsn-root-1-1-3-requested |
          | PropertyName | SourceFormatId           |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                    |
          | Key                                    | dsn-root-1-1-3-requested |
          | PropertyName                           | SourceFormatId           |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result              |
          | ReferencedSourceFormatPropertyName     | Id                       |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-1           |
          | ResultKey | dsn-root-1-1-1-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-2           |
          | ResultKey | dsn-root-1-1-1-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-2-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-2-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-1-3           |
          | ResultKey | dsn-root-1-1-1-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-1-3-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-1-3-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-2-1           |
          | ResultKey | dsn-root-1-1-2-1-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-2-1-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-2-1-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-2-2           |
          | ResultKey | dsn-root-1-1-2-2-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-2-2-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-2-2-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And DimensionStructureNode is requested
          | Field     | Value                      |
          | Key       | dsn-root-1-1-2-3           |
          | ResultKey | dsn-root-1-1-2-3-requested |

        And DimensionStructure's property is not empty
          | Field        | Value                      |
          | Key          | dsn-root-1-1-2-3-requested |
          | PropertyName | SourceFormatId             |

        And DimensionStructure's node property equals to a number
          | Field                                  | Value                      |
          | Key                                    | dsn-root-1-1-2-3-requested |
          | PropertyName                           | SourceFormatId             |
          | ExpectedResultReferenceSourceFormatKey | sf-2-result                |
          | ReferencedSourceFormatPropertyName     | Id                         |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1     |
          | ParentKey          | sf-2-root-node |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1     |
          | ParentKey | sf-2-root-node |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-1 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-2   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-2 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-3   |
          | ParentKey          | dsn-root-1     |

        And DimensionStructureNode parent in the database is
          | Field     | Value        |
          | ChildKey  | dsn-root-1-3 |
          | ParentKey | dsn-root-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-1 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-1 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-2 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value          |
          | TreeKey            | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |
          | ParentKey          | dsn-root-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value          |
          | ChildKey  | dsn-root-1-1-3 |
          | ParentKey | dsn-root-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-1 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-2 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |
          | ParentKey          | dsn-root-1-1-1   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-1-3 |
          | ParentKey | dsn-root-1-1-1   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-1 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-1 |
          | ParentKey          | dsn-root-1-1-2   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-2-1 |
          | ParentKey | dsn-root-1-1-2   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-2 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-2 |
          | ParentKey          | dsn-root-1-1-2   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-2-2 |
          | ParentKey | dsn-root-1-1-2   |

        And DimensionStructureNode is in the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-3 |

        And DimensionStructureNode parent by traversing through the tree is
          | Field              | Value            |
          | TreeKey            | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-3 |
          | ParentKey          | dsn-root-1-1-2   |

        And DimensionStructureNode parent in the database is
          | Field     | Value            |
          | ChildKey  | dsn-root-1-1-2-3 |
          | ParentKey | dsn-root-1-1-2   |