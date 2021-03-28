Feature: SourceFormat Business Logic - Delete DimensionStructureNode from tree

As a Data Owner and Data Curator
I need to be able to manage trees describe how a document structures
Which includes being able to delete nodes

# Test case:
#  SF
#  | -> RootDimensionStructureNode
#        |-> DimensionStructureNode (ds-node-to-be-added)

    Scenario: Delete DimensionStructureNode

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

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value               |
          | SourceFormatKey                    | sf-2-result         |
          | ParentDimensionStructureNodeKey    | sf-2-root-node      |
          | ToBeAddedDimensionStructureNodeKey | ds-node-to-be-added |
          | OperationResultKey                 | add-dsn-sf-result   |

        When DimensionStructureNode is deleted from tree of SourceFormat
          | Field                           | Value                |
          | DimensionStructureNodeKey       | ds-node-to-be-added  |
          | ParentDimensionStructureNodeKey | sf-2-root-node       |
          | SourceFormatKey                 | sf-2-result          |
          | OperationResultKey              | remove-dsn-sf-result |

        Then operation result is
          | Field         | Value                |
          | Key           | remove-dsn-sf-result |
          | ExpectedValue | SUCCESS              |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is not in the tree
          | Field              | Value               |
          | Key                | sf-2-with-tree      |
          | SearchForObjectKey | ds-node-to-be-added |

    #Test case
    #SF
    #| -> RootDimensionStructureNode
    #        |-> DimensionStructureNode
    #        |-> DimensionStructureNode

    Scenario: Delete DSN from level 1 when there are multiple DSNs
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
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | sf-2-root-node          |
          | ToBeAddedDimensionStructureNodeKey | ds-node1-to-be-added    |
          | OperationResultKey                 | add-dsn-node1-sf-result |

        And there is a saved DimensionStructureNode domain object
          | Field     | Value                |
          | IsActive  | 1                    |
          | ResultKey | ds-node2-to-be-added |

        And DimensionStructureNode is added to the tree of a SourceFormat
          | Field                              | Value                   |
          | SourceFormatKey                    | sf-2-result             |
          | ParentDimensionStructureNodeKey    | sf-2-root-node          |
          | ToBeAddedDimensionStructureNodeKey | ds-node2-to-be-added    |
          | OperationResultKey                 | add-dsn-node2-sf-result |

        When DimensionStructureNode is deleted from tree of SourceFormat
          | Field                           | Value                      |
          | DimensionStructureNodeKey       | ds-node2-to-be-added       |
          | ParentDimensionStructureNodeKey | sf-2-root-node             |
          | SourceFormatKey                 | sf-2-result                |
          | OperationResultKey              | remove-dsn-node2-sf-result |

        Then operation result is
          | Field         | Value                      |
          | Key           | remove-dsn-node2-sf-result |
          | ExpectedValue | SUCCESS                    |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value          |
          | Key       | sf-2-result    |
          | ResultKey | sf-2-with-tree |

        And DimensionStructureNode is not in the tree
          | Field              | Value                |
          | Key                | sf-2-with-tree       |
          | SearchForObjectKey | ds-node2-to-be-added |

        And DimensionStructureNode is in the tree
          | Field              | Value                |
          | Key                | sf-2-with-tree       |
          | SearchForObjectKey | ds-node1-to-be-added |

        And DimensionStructureNode parent is
          | Field              | Value                |
          | TreeKey            | sf-2-with-tree       |
          | SearchForObjectKey | ds-node1-to-be-added |
          | ParentKey          | sf-2-root-node       |