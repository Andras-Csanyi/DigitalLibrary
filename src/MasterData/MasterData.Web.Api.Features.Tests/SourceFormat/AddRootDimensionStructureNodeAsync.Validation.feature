Feature: SourceFormat REST Api - adding root DimensionStructureNode to SourceFormat validation

As a Data Owner and Data Curator
I need to be able to build SourceFormat data structure and add root DimensionStructure to it.

    Scenario Outline: Returns 400 when backend input validation fails

        Given there is the <SourceFormatId> SourceFormat Id
        And there is the <DoesSourceFormatExist> value whether SourceFormat exists or not
        And there is the <DimensionStructureNodeId> DimensionStructureNode Id
        And there is the <DoesDimensionStructureNodeExist> value whether DimensionStructureNode exist or not

        When DimensionStructureNode is added to SourceFormat as root DimensionStructureNode

        Then it returns
          | StatusCode |
          | 400        |

        Examples:
          | SourceFormatId | DoesSourceFormatExist | DimensionStructureNodeId | DoesDimensionStructureNodeExist |
          | 0              | false                 | 0                        | false                           |
          | 1              | false                 | 0                        | false                           |
          | 0              | false                 | 1                        | false                           |
          | 1              | true                  | 1                        | false                           |
