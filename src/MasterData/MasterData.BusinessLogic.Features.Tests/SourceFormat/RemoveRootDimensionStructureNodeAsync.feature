Feature: SourceFormat Business Logic - Remove Root DimensionStructureNode

  As a Data Owner and Data Curator
  I need to be able to build DimensionStructureNode trees
  Which includes being able to delete root DimensionStructureNode of a SourceFormat
  So that, I need a functionality providing it.

  Since DimensionStructureNodes can be attached to multiple SourceFormats the removed DimensionStructureNode is not
  going to be deleted, only the connection between them will be deleted.

  Scenario: Delete root DimensionStructureNode of a SourceFormat

    Given there is a saved SourceFormat domain object
      | Field     | Value       |
      | Name      | sf-1        |
      | Desc      | sf-1        |
      | IsActive  | 1           |
      | ResultKey | sf-1-result |

    And there is a saved DimensionStructureNode domain object
      | Field     | Value          |
      | IsActive  | 1              |
      | ResultKey | ds-node-result |

    And DimensionStructureNode is added to SourceFormat as root
      | Field                     | Value                |
      | DimensionStructureNodeKey | ds-node-result       |
      | SourceFormatKey           | sf-1-result          |
      | ResultKey                 | sf-1-root-dsn-result |

    When the root DimensionStructureNode of a SourceFormat is deleted
      | Field     | Value            |
      | Key       | sf-1-result      |
      | ResultKey | sf-1-delete-root |

    Then operation result is
      | Field         | Value            |
      | Key           | sf-1-delete-root |
      | ExpectedValue | SUCCESS          |

    And SourceFormat is requested with DimensionStructureNode tree
      | Field     | Value                   |
      | Key       | sf-1-result             |
      | ResultKey | sf-1-withtree-requested |

    And SourceFormat does not have root DimensionStructureNode
      | Field | Value                   |
      | Key   | sf-1-withtree-requested |
    