Feature: SourceFormat Business Logic - DeleteRootDimensionStructureNodeAsync

As a Data Owner and Data Curator
I have to have the ability to delete RootDimensionStructureNode

    Scenario: Deletes RootDimensionStructureNode which doesn't have child nodes

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

        When RootDimensionStructureNode of a SourceFormat is deleted
          | Field                         | Value                 |
          | RootDimensionStructureNodeKey | sf-2-root-node        |
          | SourceFormatKey               | sf-2-result           |
          | OperationResultKey            | delete-sf-2-root-node |

        Then operation result is
          | Field         | Value                 |
          | Key           | delete-sf-2-root-node |
          | ExpectedValue | SUCCESS               |

        And DimensionStructureNode is requested and result is
          | Field          | Value                    |
          | Key            | sf-2-root-node           |
          | ResultKey      | sf-2-root-node-requested |
          | ExpectedResult | null                     |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And SourceFormat does not have root DimensionStructureNode
          | Field     | Value                 |
          | Key       | sf-2-with-tree        |
          | ResultKey | sf-2-with-tree-result |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | sf-2-root-node |
          | SourceFormatKey           | sf-2-with-tree |

    Scenario: Delete root dimensionstructurenode and it removes the tree of the root node

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

        When RootDimensionStructureNode of a SourceFormat is deleted
          | Field                         | Value                 |
          | RootDimensionStructureNodeKey | sf-2-root-node        |
          | SourceFormatKey               | sf-2-result           |
          | OperationResultKey            | delete-sf-2-root-node |

        Then operation result is
          | Field         | Value                 |
          | Key           | delete-sf-2-root-node |
          | ExpectedValue | SUCCESS               |

        And DimensionStructureNode is requested and result is
          | Field          | Value                    |
          | Key            | sf-2-root-node           |
          | ResultKey      | sf-2-root-node-requested |
          | ExpectedResult | null                     |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And SourceFormat does not have root DimensionStructureNode
          | Field     | Value                 |
          | Key       | sf-2-with-tree        |
          | ResultKey | sf-2-with-tree-result |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | sf-2-root-node |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1     |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-1   |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-1-1 |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-1-1 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-1-2 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-1-3 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-1-2 |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-2-1 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-2-2 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value            |
          | DimensionStructureNodeKey | dsn-root-1-1-2-3 |
          | SourceFormatKey           | sf-2-with-tree   |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-1-3 |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-2   |
          | SourceFormatKey           | sf-2-with-tree |

        And DimensionStructureNode is not in the tree in the database
          | Field                     | Value          |
          | DimensionStructureNodeKey | dsn-root-1-3   |
          | SourceFormatKey           | sf-2-with-tree |