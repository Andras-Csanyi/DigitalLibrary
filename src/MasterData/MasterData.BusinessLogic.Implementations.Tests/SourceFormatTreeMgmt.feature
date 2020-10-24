Feature: Source format and its tree management

  As a Data Owner and Data Curator
  I need to manage data and data structure
  I need functionality to be able to do so

  Scenario: Adding source format and root dimension structure and dimension structure to the tree and tear them down

    Given there is a SourceFormat domain object
      | Field            | Value   |
      | Key              | SF1     |
      | NameProperty     | SF1     |
      | DescProperty     | SF1Desc |
      | IsActiveProperty | 1       |

    And SourceFormat is saved
      | Field     | Value       |
      | Key       | SF1         |
      | ResultKey | sf-1-result |

    And there is a saved DimensionStructure domain object
      | Field     | Value          |
      | ResultKey | ds-root-result |

    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value          |
      | SourceFormatKey       | sf-1-result    |
      | DimensionStructureKey | ds-root-result |

    And there is a saved DimensionStructure domain object
      | Field     | Value           |
      | ResultKey | ds-child-result |

    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value           |
      | ChildKey        | ds-child-result |
      | ParentKey       | ds-root-result  |
      | SourceFormatKey | sf-1-result     |

    And DimensionStructure is deleted from the tree
      | Field                 | Value                  |
      | DimensionStructureKey | ds-child-result        |
      | SourceFormatKey       | sf-1-result            |
      | ResultKey             | ds-child-delete-result |

    Then SourceFormat don't have node with DimensionStructure
      | Field                 | Value           |
      | DimensionStructureKey | ds-child-result |
      | SourceFormatKey       | sf-1-result     |