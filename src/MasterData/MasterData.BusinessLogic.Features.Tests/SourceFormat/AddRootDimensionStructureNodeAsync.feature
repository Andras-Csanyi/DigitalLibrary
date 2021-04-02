Feature: SourceFormat Business Logic - Add Root DimensionStructureNode

As a Data Owner and Data Curator
I need to be able to build DimensionStructureNode trees
Which starts with adding a Root DimensionStructureNode to a SourceFormat
So that, I need a functionality providing it.

    Scenario: Adds DimensionStructureNode as root DimensionStructureNode

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

        When DimensionStructureNode is added to SourceFormat as root
          | Field                     | Value                |
          | DimensionStructureNodeKey | ds-node              |
          | SourceFormatKey           | sf-1-result          |
          | ResultKey                 | sf-1-root-dsn-result |

        Then operation result is
          | Field         | Value                |
          | Key           | sf-1-root-dsn-result |
          | ExpectedValue | SUCCESS              |

        And SourceFormat is requested with DimensionStructureNode tree
          | Field     | Value             |
          | Key       | sf-1-result       |
          | ResultKey | sf-queried-result |

        And SourceFormat has root DimensionStructureNode
          | Field | Value             |
          | Key   | sf-queried-result |

        And DimensionStructureNode is requested
          |Field     |Value             |
          |Key       |ds-node           |
          |ResultKey |ds-node-requested |

        And DimensionStructure's property is not empty
          |Field        |Value             |
          |Key          |ds-node-requested |
          |PropertyName |SourceFormatId    |

        And DimensionStructure's node property equals to a number
          |Field                                  |Value             |
          |Key                                    |ds-node-requested |
          |PropertyName                           |SourceFormatId    |
          |ExpectedResultReferenceSourceFormatKey |sf-1-result       |
          |ReferencedSourceFormatPropertyName     |Id                |