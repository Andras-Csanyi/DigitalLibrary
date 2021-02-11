Feature: SourceFormat Business Logic - Add Root DimensionStructureNode validation

  As a Data Owner and Data Curator
  I need to be able to build DimensionStructureNode trees
  Which starts with adding a Root DimensionStructureNode to a SourceFormat
  So that, I need a functionality providing it.

  Scenario Outline: Exception is thrown when input is invalid

    Given there is a saved SourceFormat domain object
      | Field     | Value       |
      | Name      | sf-1        |
      | Desc      | sf-1        |
      | IsActive  | 1           |
      | ResultKey | sf-1-result |

    And there is a saved DimensionStructureNode domain object
      | Field     | Value   |
      | IsActive  | 1       |
      | ResultKey | ds-node |

    When in validation DimensionStructureNode is added to SourceFormat as root
      | Field                       | Value                         |
      | DimensionStructureNodeIdKey | <DimensionStructureNodeIdKey> |
      | SourceFormatIdKey           | <SourceFormatIdKey>           |
      | ResultKey                   | sf-1-root-dsn-result          |

    Then operation throws exception
      | Field | Value                |
      | Key   | sf-1-root-dsn-result |

    Examples:
      | DimensionStructureNodeIdKey | SourceFormatIdKey |
      | 0                           | sf-1-result       |
      | ds-node                     | 0                 |
      | 0                           | 0                 |
