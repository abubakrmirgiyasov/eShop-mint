import React from 'react';

const ThemeToggle = ({ layoutMode, onChandLayoutMode }) => {
    // const mode = layoutMode === l

    return (
        <div className="ms-1 header-item d-none d-sm-flex">
            <button
                onClick={""}
                type="button"
                className="btn btn-icon btn-topbar btn-ghost-secondary rounded-circle light-dark-mode"    
            >
                <i className='bx bx-moon fs-22'></i>
            </button>
        </div>
    );
}

export default ThemeToggle;
