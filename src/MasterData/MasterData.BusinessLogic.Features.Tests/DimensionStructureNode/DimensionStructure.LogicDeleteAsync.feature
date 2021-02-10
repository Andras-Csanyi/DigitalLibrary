Feature: Logical Delete of DimensionStructure

  As a Data Owner and Data Curator
  In order to keep the data and structures in check
  I need a functionality makes possible to logically delete those I don't need anymore.

  Background:
    Given there is a saved DimensionStructure domain object
      | Field     | Value         |
      | ResultKey | no-connection |
      | IsActive  | 1             |

    And there is a SourceFormat domain object
      | Field | Value |
      | Key   | sf-1  |
    And SourceFormat is saved
      | Field     | Value       |
      | Key       | sf-1        |
      | ResultKey | sf-1-result |
    And there is a saved DimensionStructure domain object
      | Field     | Value              |
      | ResultKey | sf1-root-ds-result |
      | IsActive  | 1                  |
    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value              |
      | SourceFormatKey       | sf-1-result        |
      | DimensionStructureKey | sf1-root-ds-result |

    #Scenario: DimensionStructure to be deleted is child of root dimension structure
    And there is a SourceFormat domain object
      | Field | Value |
      | Key   | sf-2  |
    And SourceFormat is saved
      | Field     | Value       |
      | Key       | sf-2        |
      | ResultKey | sf-2-result |
    And there is a saved DimensionStructure domain object
      | Field     | Value              |
      | ResultKey | sf2-root-ds-result |
      | IsActive  | 1                  |
    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value              |
      | SourceFormatKey       | sf-2-result        |
      | DimensionStructureKey | sf2-root-ds-result |
    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | child-ds-result |
      | IsActive  | 1               |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value              |
      | ChildKey        | child-ds-result    |
      | ParentKey       | sf2-root-ds-result |
      | SourceFormatKey | sf-2-result        |

    And there is a SourceFormat domain object
      | Field | Value   |
      | Key   | sf-tree |
    And SourceFormat is saved
      | Field     | Value          |
      | Key       | sf-tree        |
      | ResultKey | sf-tree-result |
    And there is a saved DimensionStructure domain object
      | Field     | Value                  |
      | ResultKey | sf-tree-root-ds-result |
      | IsActive  | 1                      |
    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | tree-1-1-result |
      | IsActive  | 1               |
    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | tree-1-2-result |
      | IsActive  | 1               |
    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | tree-1-3-result |
      | IsActive  | 1               |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-1-1-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-1-2-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-1-3-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-2-1-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-2-2-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-2-3-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-3-1-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-3-2-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-1-3-3-result |
      | IsActive  | 1                 |

    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | tree-2-1-result |
      | IsActive  | 1               |
    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | tree-2-2-result |
      | IsActive  | 1               |
    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | tree-2-3-result |
      | IsActive  | 1               |

    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-1-1-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-1-2-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-1-3-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-2-1-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-2-2-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-2-3-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-3-1-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-3-2-result |
      | IsActive  | 1                 |
    And there is a saved DimensionStructure domain object
      | Field     | Value             |
      | ResultKey | tree-2-3-3-result |
      | IsActive  | 1                 |
    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value                  |
      | SourceFormatKey       | sf-tree-result         |
      | DimensionStructureKey | sf-tree-root-ds-result |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value                  |
      | ChildKey        | tree-1-1-result        |
      | ParentKey       | sf-tree-root-ds-result |
      | SourceFormatKey | sf-tree-result         |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value                  |
      | ChildKey        | tree-1-2-result        |
      | ParentKey       | sf-tree-root-ds-result |
      | SourceFormatKey | sf-tree-result         |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value                  |
      | ChildKey        | tree-1-3-result        |
      | ParentKey       | sf-tree-root-ds-result |
      | SourceFormatKey | sf-tree-result         |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-1-1-result |
      | ParentKey       | tree-1-1-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-1-2-result |
      | ParentKey       | tree-1-1-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-1-3-result |
      | ParentKey       | tree-1-1-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-2-1-result |
      | ParentKey       | tree-1-2-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-2-2-result |
      | ParentKey       | tree-1-2-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-2-3-result |
      | ParentKey       | tree-1-2-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-3-1-result |
      | ParentKey       | tree-1-3-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-3-2-result |
      | ParentKey       | tree-1-3-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-1-3-3-result |
      | ParentKey       | tree-1-3-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value           |
      | ChildKey        | tree-2-1-result |
      | ParentKey       | tree-1-1-result |
      | SourceFormatKey | sf-tree-result  |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value           |
      | ChildKey        | tree-2-2-result |
      | ParentKey       | tree-1-2-result |
      | SourceFormatKey | sf-tree-result  |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value           |
      | ChildKey        | tree-2-3-result |
      | ParentKey       | tree-1-3-result |
      | SourceFormatKey | sf-tree-result  |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-1-1-result |
      | ParentKey       | tree-2-1-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-1-2-result |
      | ParentKey       | tree-2-1-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-1-3-result |
      | ParentKey       | tree-2-1-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-2-1-result |
      | ParentKey       | tree-2-2-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-2-2-result |
      | ParentKey       | tree-2-2-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-2-3-result |
      | ParentKey       | tree-2-2-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-3-1-result |
      | ParentKey       | tree-2-3-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-3-2-result |
      | ParentKey       | tree-2-3-result   |
      | SourceFormatKey | sf-tree-result    |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value             |
      | ChildKey        | tree-2-3-3-result |
      | ParentKey       | tree-2-3-result   |
      | SourceFormatKey | sf-tree-result    |


  Scenario: DimensionStructure doesn't have any connection

    When amount of active DimensionStructure is requested
      | Field     | Value                |
      | ResultKey | amount-before-delete |
    And DimensionStructure is logically deleted
      | Field     | Value                |
      | Key       | no-connection        |
      | ResultKey | no-connection-result |
    And amount of active DimensionStructure is requested
      | Field     | Value               |
      | ResultKey | amount-after-delete |
    And list of active DimensionStructures is requested
      | Field     | Value             |
      | ResultKey | list-after-delete |

    Then difference between lists is
      | Field           | Value                |
      | ExpectedDiff    | 1                    |
      | FirstResultKey  | amount-before-delete |
      | SecondResultKey | amount-after-delete  |
    And list of DimensionStructure doesn't contain the deleted one
      | Field                 | Value             |
      | ResultKey             | list-after-delete |
      | DimensionStructureKey | no-connection     |

  Scenario: DimensionStructure is root dimension structure of a SourceFormat

    When amount of active DimensionStructure is requested
      | Field     | Value                |
      | ResultKey | amount-before-delete |
    And DimensionStructure is logically deleted
      | Field     | Value                            |
      | Key       | sf1-root-ds-result               |
      | ResultKey | sf1-root-ds-result-delete-result |
    And amount of active DimensionStructure is requested
      | Field     | Value               |
      | ResultKey | amount-after-delete |
    And list of active DimensionStructures is requested
      | Field     | Value             |
      | ResultKey | list-after-delete |

    Then difference between lists is
      | Field           | Value                |
      | ExpectedDiff    | 1                    |
      | FirstResultKey  | amount-before-delete |
      | SecondResultKey | amount-after-delete  |
    And list of DimensionStructure doesn't contain the deleted one
      | Field                 | Value              |
      | ResultKey             | list-after-delete  |
      | DimensionStructureKey | sf1-root-ds-result |

  Scenario: DimensionStructure to be deleted is child of root dimension structure

    When amount of active DimensionStructure is requested
      | Field     | Value                |
      | ResultKey | amount-before-delete |
    And DimensionStructure is logically deleted
      | Field     | Value                         |
      | Key       | child-ds-result               |
      | ResultKey | child-ds-result-delete-result |
    And amount of active DimensionStructure is requested
      | Field     | Value               |
      | ResultKey | amount-after-delete |
    And list of active DimensionStructures is requested
      | Field     | Value             |
      | ResultKey | list-after-delete |

    Then difference between lists is
      | Field           | Value                |
      | ExpectedDiff    | 1                    |
      | FirstResultKey  | amount-before-delete |
      | SecondResultKey | amount-after-delete  |
    And list of DimensionStructure doesn't contain the deleted one
      | Field                 | Value             |
      | ResultKey             | list-after-delete |
      | DimensionStructureKey | child-ds-result   |

  Scenario: DimensionStructure to be deleted is at the first level in the tree

    When amount of active DimensionStructure is requested
      | Field     | Value                |
      | ResultKey | amount-before-delete |
    And DimensionStructure is logically deleted
      | Field     | Value                         |
      | Key       | tree-1-1-result               |
      | ResultKey | tree-1-1-result-delete-result |
    And amount of active DimensionStructure is requested
      | Field     | Value               |
      | ResultKey | amount-after-delete |
    And list of active DimensionStructures is requested
      | Field     | Value             |
      | ResultKey | list-after-delete |

    Then difference between lists is
      | Field           | Value                |
      | ExpectedDiff    | 1                    |
      | FirstResultKey  | amount-before-delete |
      | SecondResultKey | amount-after-delete  |
    And list of DimensionStructure doesn't contain the deleted one
      | Field                 | Value             |
      | ResultKey             | list-after-delete |
      | DimensionStructureKey | child-ds-result   |

  Scenario: DimensionStructure to be deleted is at the second level in the tree

    When amount of active DimensionStructure is requested
      | Field     | Value                |
      | ResultKey | amount-before-delete |
    And DimensionStructure is logically deleted
      | Field     | Value                         |
      | Key       | tree-2-2-result               |
      | ResultKey | tree-2-2-result-delete-result |
    And amount of active DimensionStructure is requested
      | Field     | Value               |
      | ResultKey | amount-after-delete |
    And list of active DimensionStructures is requested
      | Field     | Value             |
      | ResultKey | list-after-delete |

    Then difference between lists is
      | Field           | Value                |
      | ExpectedDiff    | 1                    |
      | FirstResultKey  | amount-before-delete |
      | SecondResultKey | amount-after-delete  |
    And list of DimensionStructure doesn't contain the deleted one
      | Field                 | Value             |
      | ResultKey             | list-after-delete |
      | DimensionStructureKey | child-ds-result   |