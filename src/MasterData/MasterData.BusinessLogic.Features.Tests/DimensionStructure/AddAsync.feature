Feature: DimensionStructure Business Logic - Adding DimensionStructure

  As a Data Owner and Data Curator
  I have to be able to manage DimensionStructures in the system including adding new ones
  So that, I need a functionality covering this.

  Scenario: Adds DimensionStructure

    Given there is a DimensionStructure domain object
      | Field    | Value   |
      | Key      | root-ds |

    When DimensionStructure is saved
      | Field     | Value          |
      | Key       | root-ds        |
      | ResultKey | root-ds-result |
    And DimensionStructure is requested
      | Field     | Value                    |
      | Key       | root-ds-result           |
      | ResultKey | root-ds-requested-result |

    Then DimensionStructure property equals to
      | Field         | Value                    |
      | Key           | root-ds-requested-result |
      | PropertyName  | Name                     |
      | ComparedToKey | root-ds-result           |
    Then DimensionStructure property equals to
      | Field         | Value                    |
      | Key           | root-ds-requested-result |
      | PropertyName  | Desc                     |
      | ComparedToKey | root-ds-result           |
    Then DimensionStructure property equals to
      | Field         | Value                    |
      | Key           | root-ds-requested-result |
      | PropertyName  | IsActive                 |
      | ComparedToKey | root-ds-result           |