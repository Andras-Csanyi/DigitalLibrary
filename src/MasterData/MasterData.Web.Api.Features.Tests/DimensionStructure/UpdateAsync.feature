Feature: DimensionStructure REST Endpoint - UpdateAsync

  As a Data Owner and Data Curator
  I need to be able to update DimensionStructures
  So that, I need DimensionStructure update functionality.

  Scenario Outline: DimensionStructure is updated.

    Given there is a DimensionStructure domain object
      | Field    | Value |
      | Key      | ds    |
      | Name     | asd   |
      | Desc     | asd   |
      | ISActive | 1     |
    And DimensionStructure is sent to the Add endpoint
      | Field     | Value     |
      | Key       | ds        |
      | ResultKey | ds-result |
    And stored DimensionStructure object properties are set to
      | Field     | Value         |
      | Key       | ds-result     |
      | ResultKey | ds-updated    |
      | Name      | <Name>        |
      | Desc      | <Description> |
      | IsActive  | <IsActive>    |

    When DimensionStructure is sent to the Update endpoint
      | Field     | Value            |
      | Key       | ds-updated       |
      | ResultKey | ds-update-result |

    Then DimensionStructure name property equals to
      | Field      | Value            |
      | Key        | ds-update-result |
      | ComparedTo | ds-result        |
    And DimensionStructure desc property equals to
      | Field      | Value            |
      | Key        | ds-update-result |
      | ComparedTo | ds-result        |
    And DimensionStructure IsActive property equals to
      | Field      | Value            |
      | Key        | ds-update-result |
      | ComparedTo | ds-result        |
    And DimensionStructure Id property equals to
      | Field      | Value            |
      | Key        | ds-update-result |
      | ComparedTo | ds-result        |

    Examples:
      | Name   | Description | IsActive |
      | asdasd | asd         | 1        |
      | asd    | asdasd      | 1        |
      | asd    | asd         | 0        |
      | asdasd | dsadsa      | 1        |