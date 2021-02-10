Feature: DimensionStructure Business Logic - Inactivate

  As a Data Owner and Data Curator
  In order to keep the data and structures in order
  One of the steps of making order is inactivate those DimensionStructures I don't need
  So that, I need a functionality makes possible to inactivate DimensionStructures
  These functionalities needed to be validated.

  Scenario: Inactivates DimensionStructure
    Given there is a DimensionStructure domain object
      | Field    | Value   |
      | Key      | root-ds |
      | IsActive | 1       |
    And DimensionStructure is saved
      | Field     | Value          |
      | Key       | root-ds        |
      | ResultKey | root-ds-result |

    When DimensionStructure is inactivated
      | Field     | Value               |
      | Key       | root-ds-result      |
      | ResultKey | inactivation-result |
    And DimensionStructure is requested
      | Field     | Value                                |
      | Key       | root-ds-result                       |
      | ResultKey | root-ds-inactivated-requested-result |

    Then DimensionStructure property equals to
      | Field         | Value                                |
      | Key           | root-ds-inactivated-requested-result |
      | PropertyName  | Name                                 |
      | ComparedToKey | root-ds-result                       |
    And DimensionStructure property equals to
      | Field         | Value                                |
      | Key           | root-ds-inactivated-requested-result |
      | PropertyName  | Desc                                 |
      | ComparedToKey | root-ds-result                       |
    And DimensionStructure property does not equal to
      | Field        | Value                                |
      | Key          | root-ds-inactivated-requested-result |
      | PropertyName | IsActive                             |
      | NotEqualTo   | 1                                    |