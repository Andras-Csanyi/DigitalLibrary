Feature: SourceFormat Business Logic - Delete DimensionStructureNode from middle of the tree

As a Data Owner and Data Curator
I need to be able to manage trees describe how a document structures
Which includes being able to delete nodes

    Scenario: Deletes DimensionStructureNode from middle of the tree

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

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | dsn-root-1-1-2          |
          | ToBeAddedDimensionStructureNodeKey | dsn-root-1-1-2-3        |
          | OperationResultKey                 | dsn-root-1-1-2-3-result |

        When DimensionStructureNode is deleted from tree of SourceFormat
          | Field                           | Value                      |
          | DimensionStructureNodeKey       | dsn-root-1-1               |
          | ParentDimensionStructureNodeKey | sf-2-root-node             |
          | SourceFormatKey                 | sf-2-result                |
          | OperationResultKey              | delete-ds-node-to-be-added |

        Then SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is in the tree by traversing through the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | sf-2-root-node |

        And DimensionStructureNode is in the tree by traversing through the tree
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

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1   |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-1   |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is in the tree by traversing through the tree
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

        And DimensionStructureNode is in the tree by traversing through the tree
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

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-2 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-1-2 |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value          |
          | Key                | sf-2-with-tree |
          | SearchForObjectKey | dsn-root-1-1-3 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-1-3 |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-1 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-2-1 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-2 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-2-2 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-2-3 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-2-3 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-1 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-1-1 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-2 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-1-2 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree by traversing through the tree
          | Field              | Value            |
          | Key                | sf-2-with-tree   |
          | SearchForObjectKey | dsn-root-1-1-1-3 |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-1-3 |
          | SourceFormatKey           | sf-2-with-tree   |