import React, { useState } from "react";
// Import React FilePond
import { FilePond, registerPlugin } from "react-filepond";
// Import FilePond styles
import "filepond/dist/filepond.min.css";
import FilePondPluginImageExifOrientation from "filepond-plugin-image-exif-orientation";
import FilePondPluginImagePreview from "filepond-plugin-image-preview";
import "filepond-plugin-image-preview/dist/filepond-plugin-image-preview.css";

registerPlugin(FilePondPluginImageExifOrientation, FilePondPluginImagePreview);

const PreviewMultiImage = ({ files, handleFiles }) => {
  return (
    <div>
      <FilePond
        acceptedFileTypes={[
          "image/jpeg",
          "image/png",
          "image/svg",
          "image/webp",
        ]}
        files={files}
        onupdatefiles={handleFiles}
        allowMultiple={true}
        maxFiles={10}
        data-max-file-size={"3MB"}
        name="files"
        className={"filepond filepond-input-multiple"}
      />
    </div>
  );
};

export default PreviewMultiImage;
