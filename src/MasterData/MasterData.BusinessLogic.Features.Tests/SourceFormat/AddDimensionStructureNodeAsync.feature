Feature: SourceFormat Business Logic - Add DimensionStructureNode

  As a Data Owner and Data Curator
  I have to be able to manage data structures in the system including SourceFormat
  Which includes managing the DimensionStructureNode trees of SourceFormats

  Scenario: Adds DimensionStructureNode to the root DimensionStructureNode

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

    When DimensionStructureNode is added to the tree of a SourceFormat
      | Field                              | Value               |
      | SourceFormatKey                    | sf-2-result         |
      | ParentDimensionStructureNodeKey    | sf-2-root-node      |
      | ToBeAddedDimensionStructureNodeKey | ds-node-to-be-added |
      | OperationResultKey                 | add-dsn-sf-result   |

    Then operation result is
      | Field          | Value             |
      | Key            | add-dsn-sf-result |
      | ExpectedResult | SUCCESS           |
    
    