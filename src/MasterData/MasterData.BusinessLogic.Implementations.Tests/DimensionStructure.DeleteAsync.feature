Feature: Logical Delete of DimensionStructure

  As a Data Owner and Data Curator
  In order to keep the data and structures in check
  I need a functionality makes possible to logically delete those I don't need anymore.

  Background:
    Given there is a saved DimensionStructure domain object
      | Field     | Value         |
      | ResultKey | no-connection |

    And there is a SourceFormat domain object
      | Field | Value |
      | Key   | sf-1  |
    And SourceFormat is saved
      | Field     | Value       |
      | Key       | sf-1        |
      | ResultKey | sf-1-result |
    And there is a DimensionStructure domain object
      | Field | Value       |
      | Key   | sf1-root-ds |
    And DimensionStructure is saved
      | Field     | Value              |
      | Key       | sf1-root-ds        |
      | ResultKey | sf1-root-ds-result |
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
    And there is a DimensionStructure domain object
      | Field | Value       |
      | Key   | sf2-root-ds |
    And DimensionStructure is saved
      | Field     | Value              |
      | Key       | sf2-root-ds        |
      | ResultKey | sf2-root-ds-result |
    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value              |
      | SourceFormatKey       | sf-2-result        |
      | DimensionStructureKey | sf2-root-ds-result |
    And there is a DimensionStructure domain object
      | Field | Value    |
      | Key   | child-ds |
    And DimensionStructure is saved
      | Field     | Value           |
      | Key       | child-ds        |
      | ResultKey | child-ds-result |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value              |
      | ChildKey        | child-ds-result    |
      | ParentKey       | sf2-root-ds-result |
      | SourceFormatKey | sf-2-result        |

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