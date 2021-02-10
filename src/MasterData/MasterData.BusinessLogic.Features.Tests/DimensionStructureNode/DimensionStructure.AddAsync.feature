Feature: Adding DimensionStructures

  As a data owner and data curator
  I have to be able to manage DimensionStructures
  and trees built from DimensionStructures so
  I need the capability to this

  Background:
    Given there is a SourceFormat domain object
      | Field | Value |
      | Key   | sf-1  |
    And SourceFormat is saved
      | Field     | Value       |
      | Key       | sf-1        |
      | ResultKey | sf-1-result |
    And there is a DimensionStructure domain object
      | Field | Value   |
      | Key   | root-ds |
    And DimensionStructure is saved
      | Field     | Value          |
      | Key       | root-ds        |
      | ResultKey | root-ds-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-2  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-2        |
      | ResultKey | ds-2-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-3  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-3        |
      | ResultKey | ds-3-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-4  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-4        |
      | ResultKey | ds-4-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-5  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-5        |
      | ResultKey | ds-5-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-6  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-6        |
      | ResultKey | ds-6-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-7  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-7        |
      | ResultKey | ds-7-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-8  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-8        |
      | ResultKey | ds-8-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-9  |
    And DimensionStructure is saved
      | Field     | Value       |
      | Key       | ds-9        |
      | ResultKey | ds-9-result |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | ds-10 |
    And DimensionStructure is saved
      | Field     | Value        |
      | Key       | ds-10        |
      | ResultKey | ds-10-result |
    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value          |
      | SourceFormatKey       | sf-1-result    |
      | DimensionStructureKey | root-ds-result |

  Scenario: Add new DimensionStructure
    Given there is a DimensionStructure domain object
      | Field    | Value |
      | Key      | RD    |
      | Name     | RDd   |
      | Desc     | RDd   |
      | IsActive | 1     |
    And DimensionStructure is saved
      | Field     | Value    |
      | Key       | RD       |
      | ResultKey | RDResult |
    When DimensionStructure is requested
      | Field     | Value             |
      | Key       | RDResult          |
      | ResultKey | RDResultRequested |
    Then DimensionStructure property equals to
      | Field         | Value             |
      | Key           | RDResultRequested |
      | PropertyName  | Name              |
      | ComparedToKey | RD                |
    And DimensionStructure property equals to
      | Field         | Value             |
      | Key           | RDResultRequested |
      | PropertyName  | Desc              |
      | ComparedToKey | RD                |
    And DimensionStructure property equals to
      | Field         | Value             |
      | Key           | RDResultRequested |
      | PropertyName  | IsActive          |
      | ComparedToKey | RD                |
    And DimensionStructure property does not equal to
      | Field        | Value             |
      | Key          | RDResultRequested |
      | PropertyName | Id                |
      | NotEqualTo   | 0                 |


  Scenario: Add the first DimensionStructure to the first level in the tree

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value                      |
      | Key       | sf-1-result                |
      | ResultKey | sf-1-result-request-result |

    Then 'sf-1-result-request-result' SourceFormat save result is not null
    And root DimensionStructure of 'sf-1-result-request-result' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value                      |
      | SourceFormatKey                | sf-1-result-request-result |
      | ContainedDimensionStructureKey | ds-2-result                |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value                      |
      | SourceFormatKey | sf-1-result-request-result |
      | ParentKey       | root-ds-result             |
      | ChildKey        | ds-2-result                |

  Scenario: Add the second DimensionStructure to the first level in the tree

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-3-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |

    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-3-result       |

  Scenario: Add the third DimensionStructure to the first level in the tree

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-3-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-4-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |

    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-4-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-4-result       |

  Scenario: Add the first DimensionStructure to the second level

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-3-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-4-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |

    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-4-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-4-result       |

  Scenario: Add the second DimensionStructure to the second level
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-3-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-4-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-5-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |
    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-4-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-5-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-4-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-5-result       |

  Scenario: Add the third DimensionStructure to the second level
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-3-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-4-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-5-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-6-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |
    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-4-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-5-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-6-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-4-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-5-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-6-result       |

  Scenario: Add the first DimensionStructure to the third level

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-3-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-4-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-5-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |

    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-4-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-5-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-4-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-5-result       |

  Scenario: Add the second DimensionStructure to the third level

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-3-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-4-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-5-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-6-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |

    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-4-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-5-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-6-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-4-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-5-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-6-result       |

  Scenario: Add the third DimensionStructure to the third level

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value          |
      | ChildKey        | ds-2-result    |
      | ParentKey       | root-ds-result |
      | SourceFormatKey | sf-1-result    |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-3-result |
      | ParentKey       | ds-2-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-4-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-5-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-6-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value       |
      | ChildKey        | ds-7-result |
      | ParentKey       | ds-3-result |
      | SourceFormatKey | sf-1-result |

    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | sf-1-result       |
      | ResultKey | SFRequestedResult |

    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-2-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-3-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-4-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-5-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-6-result       |
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | ds-7-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | root-ds-result    |
      | ChildKey        | ds-2-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-2-result       |
      | ChildKey        | ds-3-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-4-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-5-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-6-result       |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | ds-3-result       |
      | ChildKey        | ds-7-result       |
