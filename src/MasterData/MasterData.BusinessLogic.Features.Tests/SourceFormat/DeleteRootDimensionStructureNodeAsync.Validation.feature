Feature: SourceFormat Business Logic - DeleteRootDimensionStructureNodeAsync validation

As a Data Owner and Data Curator
I have to have the ability to delete RootDimensionStructureNode

    Scenario Outline: Deletes RootDimensionStructureNode which doesn't have child nodes

        When RootDimensionStructureNode of a SourceFormat is deleted for validation
          | Field                         | Value                          |
          | RootDimensionStructureNodeKey | <RootDimensionStructureNodeId> |
          | SourceFormatKey               | <SourceFormatId>               |
          | OperationResultKey            | delete-sf-2-root-node          |

        Then operation result is
          | Field         | Value                 |
          | Key           | delete-sf-2-root-node |
          | ExpectedValue | FAIL                  |

        Examples:
          | RootDimensionStructureNodeId | SourceFormatId |
          | 1                            | 0              |
          | 0                            | 1              |