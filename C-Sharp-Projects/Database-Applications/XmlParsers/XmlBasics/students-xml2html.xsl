<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
  <h1>Students</h1>
  <table bgcolor="#E0E0E0" cellspacing="4">
    <tr bgcolor="#EEEEEE" padding="2">
      <td>
        <b>Name</b>
      </td>
      <td>
        <b>Gender</b>
      </td>
      <td>
        <b>Birthday</b>
      </td>
      <td>
        <b>Phone</b>
      </td>
      <td>
        <b>Email</b>
      </td>
      <td>
        <b>University</b>
      </td>
      <td>
        <b>Specialty</b>
      </td>
      <td>
        <b>Faculty Number</b>
      </td>
    </tr>
	<xsl:for-each select="/students/student">
    <tr bgcolor="white" padding="2">
      <td>
        <xsl:value-of select="name"/>
      </td>
      <td>
        <xsl:value-of select="gender"/>
      </td>
      <td>
        <xsl:value-of select="birthday"/>
      </td>
      <td>
        <xsl:value-of select="phoneNumber"/>
      </td>
      <td>
        <xsl:value-of select="email"/>
      </td>
      <td>
        <xsl:value-of select="university"/>
      </td>
      <td>
        <xsl:value-of select="specialty"/>
      </td>
      <td>
        <xsl:value-of select="facultyNumber"/>
      </td>
    </tr>
  </xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>
