<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/TR/REC-html40">
	<xsl:output method="html" encoding="UTF-8"/>
	
	<xsl:template match="/">
	
<HTML>
<HEAD>
<TITLE><xsl:value-of select="/simple-patent-document/bibliographic-data/invention-title"/></TITLE>
</HEAD>
<BODY>

<h2>
<xsl:value-of select="/simple-patent-document/bibliographic-data/publication-reference/document-id/country"/>
<xsl:value-of select="/simple-patent-document/bibliographic-data/publication-reference/document-id/doc-number"/>
<xsl:value-of select="/simple-patent-document/bibliographic-data/publication-reference/document-id/kind"/>
</h2>
<h2><xsl:value-of select="/simple-patent-document/bibliographic-data/invention-title"/></h2>

<h2>Referatas</h2>

<xsl:apply-templates select="/simple-patent-document/abstract/p"/>

<h2>Apra&#353;ymas</h2>
<xsl:apply-templates select="/simple-patent-document/description/p"/>


<h2>Apibr&#279;&#382;tys</h2>
<xsl:apply-templates select= "//claim-text"/>
<h2>Br&#279;&#382;iniai</h2>
<xsl:apply-templates select= "//figure/img"/>

</BODY>
</HTML>
</xsl:template>


<xsl:template match="claims/claim/claim-text">
<P><I><xsl:text> </xsl:text><xsl:apply-templates/></I></P>
</xsl:template>

	
	<xsl:template match="/simple-patent-document/bibliographic-data/invention-title[@lang='lt']">
<P><B><xsl:apply-templates/></B></P>
</xsl:template>


<xsl:template match="description/p">
<P><B>[<xsl:value-of select="./@num"/>]<xsl:text> </xsl:text></B><xsl:apply-templates/></P>
</xsl:template>
	
<xsl:template match="abstract[@lang='lt']/p">
<P><B>[LT] </B> <xsl:apply-templates/></P>
</xsl:template>

<xsl:template match="abstract[@lang='en']/p">
<P><B>[EN] </B> <xsl:apply-templates/></P>
</xsl:template>
	

<xsl:template match="img">
	<br /><center>
<img>
<xsl:attribute name="src">
<xsl:value-of select="./@file"/>
</xsl:attribute>

<xsl:attribute name="height">
<xsl:value-of select="./@he*4"/>
</xsl:attribute>
<xsl:attribute name="width">
<xsl:value-of select="./@wi*4"/>
</xsl:attribute>

<xsl:apply-templates/>
</img></center>
</xsl:template>
		
	<xsl:template match="bibliographic-data/invention-title[@lang='en'] | abstract | bibliographic-data/classifications-ipcr | claims"/>	
	
	</xsl:stylesheet>
	

