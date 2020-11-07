Feature: SourceFormat REST Api - Delete a SourceFormat

  As a Data Owner and Data Curator
  I need to be able to delete a SourceFormat
  So that, I need a functionality providing this.

  Scenario: SourceFormat is deleted

    Given there is a SourceFormat domain object
      | Field    | Value |
      | Name     | asd   |
      | Desc     | asd   |
      | IsActive | 0     |
      | Key      | sf    |
    And SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value     |
      | Key       | sf        |
      | ResultKey | sf-result |

    When SourceFormat is sent to SourceFormat endpoint delete method
      | Field     | Value            |
      | Key       | sf-result        |
      | ResultKey | sf-delete-result |
    And I request list of SourceFormats
      | Field     | Value   |
      | ResultKey | sf-list |

    Then the length of the list is
      | Field          | Value   |
      | Key            | sf-list |
      | ExpectedAmount | 0       |