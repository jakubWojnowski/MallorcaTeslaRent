
export const logout = ( ): Promise<void> => {

    return new Promise((resolve) => {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        resolve();
    
    });
};