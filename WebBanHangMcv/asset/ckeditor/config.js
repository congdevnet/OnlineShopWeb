/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.enterMode = CKEDITOR.ENTER_BR;
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Set the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Simplify the dialog windows.
	// Cau hinh vs CKfinder

	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl = '/asset/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/asset/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = '/asset/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '/asset/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/ImgFile';
	config.filebrowserFlashUploadUrl = '/asset/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

	CKFinder.setupCKEditor(null, '/asset/ckfinder/');
};
